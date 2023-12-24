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

        ///////////////////////////////////////////////////////    v v v   Fill SubtitleList With Regex  v v v   ///////////////////////////////////////////////////////
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
                SubtitleList.Add(new Subtitle { SubNumber = Convert.ToInt32(match.Groups["No"].Value), SubTimeText = TimeText, SubTimeStart = Convert.ToInt32(StartTime), SubTimeEnd = Convert.ToInt32(EndTime), SubContent = match.Groups["Content"].Value, SubColor = "No-Color" });
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
                string colorString = ColorPicker(SubtitleList[i].SubColor);
                int[] colorComponents = colorString.Split(',').Select(int.Parse).ToArray();
                dataGridView.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(colorComponents[0], colorComponents[1], colorComponents[2], colorComponents[3]);

                if (SubtitleList[i].SubColor == "Divergent")
                {
                    dataGridView.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                if (SubtitleList[i].SubColor == "Double")
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




        ///////////////////////////////////////////////////////    v v v   Color Picker  v v v   ///////////////////////////////////////////////////////
        public string ColorPicker(string color)
        {
            switch (color)
            {
                case "M-Blue":
                    return "255,39,133,189";
                case "M-LBlue":
                    return "255,112,191,255";
                case "M-Green":
                    return "255,150,195,98";
                case "M-Yellow":
                    return "255,255,197,113";
                case "F-Orange":
                    return "255,249,184,79";
                case "F-Brown":
                    return "255,244,102,92";
                case "F-Red":
                    return "255,216,65,120";
                case "F-Purple":
                    return "255,189,123,200";
                case "No-Color":
                    return "255,216, 191, 216 ";
                case "Sync":
                    return "255,216, 191, 200 ";
                default:
                    return ""; // or handle the default case accordingly
            }
        }

        ///////////////////////////////////////////////////////    v v v   Window Functionality  v v v   ///////////////////////////////////////////////////////
        ///
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
        public string? SubColor;
    }
}


