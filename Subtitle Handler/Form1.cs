using System.Collections.Generic;
using System.Data;
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
            }
        }

        ///////////////////////////////////////////////////////    v v v   .SRT to SubtitleList With Regex  v v v   ///////////////////////////////////////////////////////
        private void FillSubtitleList(string input)
        {
            string pattern = @"(?<No>\d+)[\r\n]((?<StartHour>\d+):(?<StartMinute>\d+):(?<StartSecond>\d+),(?<StartMilSecond>\d+) --> (?<EndHour>\d+):(?<EndMinute>\d+):(?<EndSecond>\d+),(?<EndMilSecond>\d+))[\r\n](?<Content>(.+\r?\n)+(?=(\r?\n)?))";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches.Cast<Match>())
            {
                string StartTime = match.Groups["StartHour"].Value + match.Groups["StartMinute"].Value + match.Groups["StartSecond"].Value + match.Groups["StartMilSecond"].Value;
                string EndTime = match.Groups["EndHour"].Value + match.Groups["EndMinute"].Value + match.Groups["EndSecond"].Value + match.Groups["EndMilSecond"].Value;
                string TimeText = match.Groups["StartHour"].Value + ":" + match.Groups["StartMinute"].Value + ":" + match.Groups["StartSecond"].Value + "," + match.Groups["StartMilSecond"].Value
                + " --> "
                + match.Groups["EndHour"].Value + ":" + match.Groups["EndMinute"].Value + ":" + match.Groups["EndSecond"].Value + "," + match.Groups["EndMilSecond"].Value;
                SubtitleList.Add(new Subtitle { SubNumber = Convert.ToInt32(match.Groups["No"].Value), SubTimeText = TimeText, SubTimeStart = Convert.ToInt32(StartTime), SubTimeEnd = Convert.ToInt32(EndTime), SubContent = match.Groups["Content"].Value, SubColor = GlobalColors.NoColor });
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
            SubtitleList = [.. SubtitleList.OrderBy(o => o.SubTimeText)];
            for (int i = 0; i < SubtitleList.Count; i++)
            {
                SubtitleList[i].SubNumber = i + 1;
                dataTable.Rows.Add(SubtitleList[i].SubNumber, SubtitleList[i].SubTimeText, SubtitleList[i].SubContent);
            }

            dataGridView.DataSource = dataTable;
            DesignDataGridView();
        }

        ///////////////////////////////////////////////////////    v v v   Design DataGridView  v v v   ///////////////////////////////////////////////////////
        public void DesignDataGridView()
        {
            // Set the width for each column
            dataGridView.Columns["No"].Width = 35;
            dataGridView.Columns["No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns["Time"].Width = 60;
            dataGridView.Columns["Content"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;  // Third column 40px

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
                //sayiTextBox.Text = row.Cells["sayi"].Value.ToString();
                timeTextBox.Text = row.Cells["Time"].Value.ToString();
                contentTextBox.Text = row.Cells["Content"].Value.ToString();
            }
        }


        ///////////////////////////////////////////////////////    v v v   Update Buttons  v v v   ///////////////////////////////////////////////////////
        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpdateList(null);
        }

        private void blueBtn_Click(object sender, EventArgs e)
        {
            UpdateList(GlobalColors.MLBlue);
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
            SubtitleList[rowNumber].SubTimeText = timeTextBox.Text;

            //LISTEDEKI ROW SAYILARINI TEXBOXTAKI METINDEN ALIP  GUNCELLEME
            string input = timeTextBox.Text;
            string pattern = @"(?<sure1>\d+):(?<sure2>\d+):(?<sure3>\d+),(?<sure4>\d+) --> (?<sure5>\d+):(?<sure6>\d+):(?<sure7>\d+),(?<sure8>\d+)";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches.Cast<Match>())
            {
                string subSureStart = match.Groups["sure1"].Value + match.Groups["sure2"].Value + match.Groups["sure3"].Value + match.Groups["sure4"].Value;
                string subSureEnd = match.Groups["sure5"].Value + match.Groups["sure6"].Value + match.Groups["sure7"].Value + match.Groups["sure8"].Value;
                SubtitleList[rowNumber].SubTimeStart = Convert.ToInt32(subSureStart);
                SubtitleList[rowNumber].SubTimeEnd = Convert.ToInt32(subSureEnd);
            }
        }



        ///////////////////////////////////////////////////////    v v v   Next Liner  v v v   ///////////////////////////////////////////////////////
        public void NextLine(int rowNumber)
        {
            dataGridView.Rows[rowNumber].Selected = false;
            dataGridView.Rows[0].Selected = false;
            if (rowNumber < dataGridView.Rows.Count - 1)
            {   //Choosing Next Row
                dataGridView.Rows[++rowNumber].Selected = true;
                //Centering the row in the middle of the screen
                if (rowNumber > 6) { dataGridView.FirstDisplayedScrollingRowIndex = (dataGridView.SelectedRows[0].Index) - 5; }
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
                //int penWidth = 4;
                //pen.Width = penWidth;

                //int x = e.RowBounds.Left + (penWidth / 2);
                //int y = e.RowBounds.Top + (penWidth / 2)-2;
                //int width = e.RowBounds.Width - penWidth;
                //int height = e.RowBounds.Height - penWidth+3;
                //e.Graphics.DrawRectangle(pen, x, y, width, height);


            }
        }

       




        //End of the class
    }

    //Incoming Subtitle Class
    public class Subtitle
    {
        public int SubNumber;
        public string? SubTimeText;
        public double SubTimeStart;
        public double SubTimeEnd;
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


