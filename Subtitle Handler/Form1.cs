using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Subtitle_Handler
{
    public partial class Form1 : Form
    {
        public List<Subtitle> SubtitleList = [];
        public Form1()
        {
            InitializeComponent();
            //Removing name and the control box
            this.Text = string.Empty;
            this.ControlBox = false;
            //When maximized the form will not cover the taskbar
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        ///////////////////////////////////////////////////////    v v v   Open Files  v v v   ///////////////////////////////////////////////////////
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Filter = "srt Files (*.srt)|*.srt|txt Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SubtitleList.Clear();
                string input = File.ReadAllText(ofd.FileName);
                FillSubtitleList(input);
                FillDataGridView();
                DesignDataGridView();
            }
        }

        ///////////////////////////////////////////////////////    v v v   .SRT to SubtitleList With Regex  v v v   ///////////////////////////////////////////////////////
        private void FillSubtitleList(string input)
        {
            string pattern = @"(?<No>\d+)\s*(?:(?<SubColor>\d+,\s*\d+,\s*\d+,\s*\d+)\s*)?(?<StartTime>(\d+):(\d+):(\d+),(\d+))\s*-->\s*(?<EndTime>(\d+):(\d+):(\d+),(\d+))\s*[\r\n](?<Content>([^\r\n]+\r?\n)+(?=(\r?\n)?))";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches.Cast<Match>())
            {
                Subtitle subtitle = new Subtitle
                {
                    SubNumber = Convert.ToInt32(match.Groups["No"].Value),
                    SubStartTime = match.Groups["StartTime"].Value,
                    SubEndTime = match.Groups["EndTime"].Value,
                    SubContent = match.Groups["Content"].Value,
                    SubColor = match.Groups["SubColor"].Success ? ParseColor(match.Groups["SubColor"].Value) : GlobalColors.NoColor
                };

                SubtitleList.Add(subtitle);
            }
        }

        ///////////////////////////////////////////////////////    v v v   String to Int[]  v v v   ///////////////////////////////////////////////////////
        private int[] ParseColor(string colorString)
        {
            // Implement the logic to parse the color string into an int array
            // For example, you can use Split and Select to convert the string into an array of integers
            return colorString.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
        }


        ///////////////////////////////////////////////////////    v v v   Fill DataGridView  v v v   ///////////////////////////////////////////////////////
        public void FillDataGridView()
        {

            DataTable dataTable = new();
            dataTable.Columns.Add("No", typeof(int));
            dataTable.Columns.Add("Time", typeof(string));
            dataTable.Columns.Add("Content", typeof(string));

            //Only thing matter for sorting is the time
            SubtitleList = [.. SubtitleList.OrderBy(o => o.SubStartTime)];
            for (int i = 0; i < SubtitleList.Count; i++)
            {
                SubtitleList[i].SubNumber = i + 1;
                dataTable.Rows.Add(SubtitleList[i].SubNumber, SubtitleList[i].SubStartTime + " --> " + SubtitleList[i].SubEndTime, SubtitleList[i].SubContent);
            }

            dataGridView.DataSource = dataTable;
            PaintDataGridView();
        }

        ///////////////////////////////////////////////////////    v v v   Paint DataGridView  v v v   ///////////////////////////////////////////////////////
        public void PaintDataGridView()
        {
            for (int i = 0; i < SubtitleList.Count; i++)
            {
                dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(SubtitleList[i].SubColor[0], SubtitleList[i].SubColor[1], SubtitleList[i].SubColor[2], SubtitleList[i].SubColor[3]);

                if (SubtitleList[i].SubColor == GlobalColors.Sync)
                {
                    dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                if (SubtitleList[i].SubColor == GlobalColors.Sync)
                {
                    dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }
        ///////////////////////////////////////////////////////    v v v   Design DataGridView  v v v   ///////////////////////////////////////////////////////
        public void DesignDataGridView()
        {
            // Set the width for each column
            dataGridView.Columns["No"].Width = 35;
            dataGridView.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["Time"].Width = 60;
            dataGridView.Columns["Content"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;  // Third column 40px
        }

        ///////////////////////////////////////////////////////    v v v   Row Clicked  v v v   ///////////////////////////////////////////////////////
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell? cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                string subNumber = row.Cells["No"].Value.ToString();
                startTimeTextBox.Text = SubtitleList[Convert.ToInt32(subNumber) - 1].SubStartTime;
                endTimeTextBox.Text = SubtitleList[Convert.ToInt32(subNumber) - 1].SubEndTime;
                contentTextBox.Text = row.Cells["Content"].Value.ToString();
            }
        }



        ///////////////////////////////////////////////////////    v v v   Updater  v v v   ///////////////////////////////////////////////////////
        public void UpdateList(int[]? color)
        {
            int rowNumber = dataGridView.SelectedRows[0].Index;
            TextBoxToSubtitleList(rowNumber, color);
            FillDataGridView();
            NextLine(rowNumber);
        }

        ///////////////////////////////////////////////////////    v v v   TextBox to DataGridView  v v v   ///////////////////////////////////////////////////////
        public void TextBoxToSubtitleList(int rowNumber, int[]? color)
        {
            if (color != null) SubtitleList[rowNumber].SubColor = color;
            SubtitleList[rowNumber].SubContent = contentTextBox.Text;
            SubtitleList[rowNumber].SubStartTime = startTimeTextBox.Text;
            SubtitleList[rowNumber].SubEndTime = endTimeTextBox.Text;

        }

        ///////////////////////////////////////////////////////    v v v   Time Converter  v v v   ///////////////////////////////////////////////////////
        public void TimeConventer(string? time)
        {
            string input = time;
            string pattern = @"(?<StartHour>\d+):(?<StartMinute>\d+):(?<StartSecond>\d+),(?<StartMilSecond>\d+) --> (?<EndHour>\d+):(?<EndMinute>\d+):(?<EndSecond>\d+),(?<EndMilSecond>\d+)";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches.Cast<Match>())
            {
                string subSureStart = match.Groups["sure1"].Value + match.Groups["sure2"].Value + match.Groups["sure3"].Value + match.Groups["sure4"].Value;
                string subSureEnd = match.Groups["sure5"].Value + match.Groups["sure6"].Value + match.Groups["sure7"].Value + match.Groups["sure8"].Value;

            }
        }




        ///////////////////////////////////////////////////////    v v v   Next Liner  v v v   ///////////////////////////////////////////////////////
        public void NextLine(int rowNumber)
        {
            if (rowNumber >= 0 && rowNumber < dataGridView.Rows.Count)
            {
                dataGridView.Rows[rowNumber].Selected = false;
            }
            else if (dataGridView.Rows.Count > 0)
            {
                // Set it to the index of the last row
                int lastRowIndex = dataGridView.Rows.Count - 1;
                dataGridView.Rows[lastRowIndex].Selected = false;
            }
            dataGridView.Rows[0].Selected = false;
            if (rowNumber < dataGridView.Rows.Count - 1)
            {   //Choosing Next Row
                dataGridView.Rows[++rowNumber].Selected = true;
                //Centering the row in the middle of the screen
                if (rowNumber > 6) { dataGridView.FirstDisplayedScrollingRowIndex = (dataGridView.SelectedRows[0].Index) - 5; }
            }
        }



        ///////////////////////////////////////////////////////    v v v   Update Buttons  v v v   ///////////////////////////////////////////////////////
        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpdateList(null);
        }

        private void blueBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.MBlue);
        }
        private void lightBlueBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.MLBlue);
        }

        private void greenBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.MGreen);
        }

        private void yellowBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.MYellow);
        }

        private void purpleBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.FPurple);
        }

        private void pinkBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.FRed);
        }

        private void brownBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.FBrown);
        }

        private void orangeBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.FOrange);
        }

        ///////////////////////////////////////////////////////                                          ///////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////    v v v   Window Functionality  v v v   ///////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////                                          ///////////////////////////////////////////////////////
        /////Since control box is gone theese are for dragging the window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void closeWindowBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maxBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        ///////////////////////////////////////////////////////    v v v   DataGridView Design  v v v   ///////////////////////////////////////////////////////
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].Selected)
            {
                using Pen pen = new(Color.Black);
                var row = dataGridView.Rows[e.RowIndex];
                var bgColor = row.DefaultCellStyle.BackColor;
                var fontColor = row.DefaultCellStyle.ForeColor;
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(bgColor.R * 5 / 6, bgColor.G * 5 / 6, bgColor.B * 5 / 6);
                row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(fontColor.R * 5 / 6, fontColor.G * 5 / 6, fontColor.B * 5 / 6);

                //IF YOU WANT TO DRAW A BORDER AROUND THE SELECTED ROW
                //int penWidth = 4;
                //pen.Width = penWidth;

                //int x = e.RowBounds.Left + (penWidth / 2);
                //int y = e.RowBounds.Top + (penWidth / 2)-2;
                //int width = e.RowBounds.Width - penWidth;
                //int height = e.RowBounds.Height - penWidth+3;
                //e.Graphics.DrawRectangle(pen, x, y, width, height);


            }
        }

        ///////////////////////////////////////////////////////    v v v   Add Row  v v v   ///////////////////////////////////////////////////////
        private void addRowBtn_Click(object sender, EventArgs e)
        {
            int rowNumber = dataGridView.SelectedRows[0].Index;
            AddRow(rowNumber);
            FillDataGridView();
            NextLine(rowNumber);
        }

        public void AddRow(int rowNumber)
        {

            SubtitleList.Insert(rowNumber + 1, new Subtitle { SubNumber = SubtitleList[rowNumber].SubNumber, SubStartTime = SubtitleList[rowNumber].SubStartTime, SubEndTime = SubtitleList[rowNumber].SubEndTime, SubContent = SubtitleList[rowNumber].SubContent, SubColor = SubtitleList[rowNumber].SubColor });
        }



        ///////////////////////////////////////////////////////    v v v   Delete Row  v v v   ///////////////////////////////////////////////////////
        private void dltRowBtn_Click(object sender, EventArgs e)
        {
            int rowNumber = dataGridView.SelectedRows[0].Index;
            SubtitleList.RemoveAt(rowNumber);
            FillDataGridView();
            NextLine(rowNumber - 1);
        }


        ///////////////////////////////////////////////////////    v v v   Save Button  v v v   ///////////////////////////////////////////////////////

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveAs("Save", null);
            MessageBox.Show("Current Progress saved as: " + $"save.srt"
                + Environment.NewLine + "!!Next save will rewrite same file if you dont change name or location of the file");
        }

        ///////////////////////////////////////////////////////    v v v   Extract Button  v v v   ///////////////////////////////////////////////////////
        private void extractBtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("here: extract Button");
            foreach (var colorProperty in typeof(GlobalColors).GetFields())
            {
                Debug.WriteLine("here:inside foreach extract");
                var colorName = colorProperty.Name;
                var colorValue = (int[])colorProperty.GetValue(null);

                Debug.WriteLine("colorname:"+colorName+"\ncolorValue:"+colorValue);
                SaveAs(colorName, colorValue);
            }
            MessageBox.Show("Current Progress saved."
                + Environment.NewLine + "!!Next save will rewrite same file if you dont change name or location of the file");
        }


        ///////////////////////////////////////////////////////    v v v   Save As  v v v   ///////////////////////////////////////////////////////
        public void SaveAs(string name, int[] colorValue)
        {
                using TextWriter tw = new StreamWriter($"{name}.srt");
                Save(tw, colorValue);
        }

        ///////////////////////////////////////////////////////    v v v   Save Progress  v v v   ///////////////////////////////////////////////////////
        public void Save(TextWriter tw, int[] colorFilter)
        {
            List<Subtitle> filteredSubtitles;

            if (colorFilter == null)
            {
                Debug.WriteLine("here: save");
                // No color filter specified, use all subtitles
                filteredSubtitles = SubtitleList;
            }
            else
            {
                Debug.WriteLine("here: extract");
                // Filter subtitles based on SubColor
                filteredSubtitles = SubtitleList.Where(sub =>
                    Enumerable.SequenceEqual(sub.SubColor, colorFilter) ).ToList();
                Debug.WriteLine(filteredSubtitles);
            }

            foreach (Subtitle subtitle in filteredSubtitles)
            {
                tw.WriteLine(subtitle.SubNumber);
                tw.WriteLine(subtitle.SubStartTime + " --> " + subtitle.SubEndTime);
                tw.WriteLine(subtitle.SubContent);
                tw.WriteLine();
            }
        }

















        //End of the class
    }

    //Incoming Subtitle Class
    public class Subtitle
    {
        public int SubNumber;
        public string? SubStartTime;
        public string? SubEndTime;
        public string? SubContent;
        public required int[] SubColor;
    }
    public static class GlobalColors
    {
        public static int[] MBlue = { 255, 39, 133, 189 };
        public static int[] MLBlue = { 255, 112, 191, 255 };
        public static int[] MGreen = { 255, 150, 195, 98 };
        public static int[] MYellow = { 255, 255, 197, 113 };
        public static int[] FOrange = { 255, 249, 184, 79 };
        public static int[] FBrown = { 255, 244, 102, 92 };
        public static int[] FRed = { 255, 216, 65, 120 };
        public static int[] FPurple = { 255, 189, 123, 200 };
        public static int[] NoColor = { 255, 216, 191, 216 };
        public static int[] Sync = { 255, 216, 191, 200 };
    }
}

