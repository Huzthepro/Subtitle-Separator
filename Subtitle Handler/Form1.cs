using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

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
                string input = File.ReadAllText(ofd.FileName);

                //If new file is opened clear the list
                SubtitleList.Clear();
                FillSubtitleList(input);
                FillDataGridView();
                DesignDataGridView();
            }
        }

        ///////////////////////////////////////////////////////    v v v   .SRT to SubtitleList With Regex  v v v   ///////////////////////////////////////////////////////
        private void FillSubtitleList(string input)
        {
            string pattern = @"(?<No>\d+)\s*(?:(?<SubColor>\w+)\s*)?(?<StartTime>(\d+):(\d+):(\d+),(\d+))\s*-->\s*(?<EndTime>(\d+):(\d+):(\d+),(\d+))\s*[\r\n](?<Content>([^\r\n]+\r?\n)+(?=(\r?\n)?))";
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches.Cast<Match>())
            {
                Subtitle subtitle = new Subtitle
                {
                    SubNumber = Convert.ToInt32(match.Groups["No"].Value),
                    SubStartTime = match.Groups["StartTime"].Value,
                    SubEndTime = match.Groups["EndTime"].Value,
                    SubContent = match.Groups["Content"].Value,
                    //Only save files have color line in them
                    SubColorName = match.Groups["SubColor"].Success
                        ? GetColorConstant(match.Groups["SubColor"].Value)
                        : GlobalColors.NoColor
                };

                SubtitleList.Add(subtitle);
            }
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
                string colorName = SubtitleList[i].SubColorName;

                if (GlobalColors.ColorDictionary.TryGetValue(colorName, out var colorArray))
                {
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(colorArray[0], colorArray[1], colorArray[2], colorArray[3]);
                }
                else
                {
                    // Handle the case when the color name is not found in the dictionary
                    dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
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
            dataGridView.Columns["Content"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
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
        public void UpdateList(string? colorName)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int rowNumber = dataGridView.SelectedRows[0].Index;
                TextBoxToSubtitleList(rowNumber, colorName);
                FillDataGridView();
                NextLine(rowNumber);
            }
        }

        ///////////////////////////////////////////////////////    v v v   TextBox to SubtitleList  v v v   ///////////////////////////////////////////////////////
        public void TextBoxToSubtitleList(int rowNumber, string? colorName)
        {
            if (colorName != null) SubtitleList[rowNumber].SubColorName = colorName;
            SubtitleList[rowNumber].SubContent = contentTextBox.Text;
            SubtitleList[rowNumber].SubStartTime = startTimeTextBox.Text;
            SubtitleList[rowNumber].SubEndTime = endTimeTextBox.Text;
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

        ///////////////////////////////////////////////////////    v v v   Add Row  v v v   ///////////////////////////////////////////////////////
        private void addRowBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int rowNumber = dataGridView.SelectedRows[0].Index;
                AddRow(rowNumber);
                FillDataGridView();
                NextLine(rowNumber);
            }
        }

        public void AddRow(int rowNumber)
        {
            SubtitleList.Insert(rowNumber + 1, new Subtitle { SubNumber = SubtitleList[rowNumber].SubNumber, SubStartTime = SubtitleList[rowNumber].SubStartTime, SubEndTime = SubtitleList[rowNumber].SubEndTime, SubContent = SubtitleList[rowNumber].SubContent, SubColorName = SubtitleList[rowNumber].SubColorName });
        }

        ///////////////////////////////////////////////////////    v v v   Delete Row  v v v   ///////////////////////////////////////////////////////
        private void dltRowBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int rowNumber = dataGridView.SelectedRows[0].Index;
                SubtitleList.RemoveAt(rowNumber);
                FillDataGridView();
                NextLine(rowNumber - 1);
            }
        }

        ///////////////////////////////////////////////////////    v v v   String to GlobalColors.Color  v v v   ///////////////////////////////////////////////////////
        private string GetColorConstant(string colorName)
        {
            // Use reflection to get the value of the constant in GlobalColors
            var field = typeof(GlobalColors).GetField(colorName);
            if (field != null)
            {
                return field.GetValue(null) as string;
            }

            return GlobalColors.NoColor;
        }

        ///////////////////////////////////////////////////////    v v v   Update Buttons  v v v   ///////////////////////////////////////////////////////
        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpdateList(null);
        }

        private void blueBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.DarkBlue);
        }
        private void lightBlueBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.LightBlue);
        }
        private void greenBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.Green);
        }
        private void yellowBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.Yellow);
        }
        private void purpleBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.Purple);
        }
        private void pinkBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.Red);
        }
        private void brownBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.Brown);
        }
        private void orangeBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.Orange);
        }

        ///////////////////////////////////////////////////////                            ///////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////    v v v   Saving  v v v   ///////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////                            ///////////////////////////////////////////////////////

        private void saveBtn_Click(object sender, EventArgs e)
        {  
            using TextWriter tw = new StreamWriter($"Save.srt");
            Save(tw, null);
        }

        private void extractBtn_Click(object sender, EventArgs e)
        {
            foreach (var colorProperty in typeof(GlobalColors).GetFields())
            {
                var colorName = colorProperty.Name;
                var subtitlesForColor = SubtitleList.Where(sub => sub.SubColorName == colorName).ToList();
                if (subtitlesForColor.Any())
                {
                    using TextWriter tw = new StreamWriter($"{colorName}.srt");
                    Save(tw, colorName);
                }
            }
        }

        public void Save(TextWriter tw, string colorFilter)
        {
            List<Subtitle> filteredSubtitles;

            if (colorFilter == null)
            {
                filteredSubtitles = SubtitleList;
            }
            else
            {
                filteredSubtitles = SubtitleList.Where(sub =>
                    Enumerable.SequenceEqual(sub.SubColorName, colorFilter)).ToList();
            }

            foreach (Subtitle subtitle in filteredSubtitles)
            {
                tw.WriteLine(subtitle.SubNumber);

                if (colorFilter == null)
                {
                    tw.WriteLine(subtitle.SubColorName);
                }

                tw.WriteLine(subtitle.SubStartTime + " --> " + subtitle.SubEndTime);
                tw.WriteLine(subtitle.SubContent);
                tw.WriteLine();
            }
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
                //int penWidth = 2;
                //pen.Width = penWidth;
                //int x = e.RowBounds.Left + (penWidth / 2);
                //int y = e.RowBounds.Top + (penWidth / 2) - 2;
                //int width = e.RowBounds.Width - penWidth;
                //int height = e.RowBounds.Height - penWidth + 3;
                //e.Graphics.DrawRectangle(pen, x, y, width, height);
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
        public string SubColorName { get; set; }
    }
    public static class GlobalColors
    {
        public const string DarkBlue = nameof(DarkBlue);
        public const string LightBlue = nameof(LightBlue);
        public const string Green = nameof(Green);
        public const string Yellow = nameof(Yellow);
        public const string Orange = nameof(Orange);
        public const string Brown = nameof(Brown);
        public const string Red = nameof(Red);
        public const string Purple = nameof(Purple);
        public const string NoColor = nameof(NoColor);

        public static Dictionary<string, int[]> ColorDictionary = new Dictionary<string, int[]>
    {
        { DarkBlue, new int[] { 255, 39, 133, 189 } },
        { LightBlue, new int[] { 255, 112, 191, 255 } },
        { Green, new int[] { 255, 150, 195, 98 } },
        { Yellow, new int[] { 255, 255, 197, 113 } },
        { Orange, new int[] { 255, 249, 184, 79 } },
        { Brown, new int[] { 255, 244, 102, 92 } },
        { Red, new int[] { 255, 216, 65, 120 } },
        { Purple, new int[] { 255, 189, 123, 200 } },
        { NoColor, new int[] { 255, 216, 191, 216 } }
    };

        public static int[] GetColorArray(string colorName)
        {
            if (ColorDictionary.TryGetValue(colorName, out var colorArray))
            {
                return colorArray;
            }

            return null; // Return null or some default value if the color name is not found
        }
    }
}

