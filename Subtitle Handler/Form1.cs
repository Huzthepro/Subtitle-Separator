using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Subtitle_Handler
{
    public partial class Form1 : Form
    {
        public List<Subtitle> SubtitleList = new List<Subtitle>();
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "srt Files (*.srt)|*.srt|txt Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                SubtitleList.Clear();
                string input = File.ReadAllText(ofd.FileName);
                string pattern = @"(?<sira>\d+)[\r\n]((?<sure1>\d+):(?<sure2>\d+):(?<sure3>\d+),(?<sure4>\d+) --> (?<sure5>\d+):(?<sure6>\d+):(?<sure7>\d+),(?<sure8>\d+))[\r\n](?<metin>(.+\r?\n)+(?=(\r?\n)?))";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    string subSureStart = match.Groups["sure1"].Value + match.Groups["sure2"].Value + match.Groups["sure3"].Value + match.Groups["sure4"].Value;
                    string subSureEnd = match.Groups["sure5"].Value + match.Groups["sure6"].Value + match.Groups["sure7"].Value + match.Groups["sure8"].Value;
                    string subSureMetin = match.Groups["sure1"].Value + ":" + match.Groups["sure2"].Value + ":" + match.Groups["sure3"].Value + "," + match.Groups["sure4"].Value + " --> " + match.Groups["sure5"].Value + ":" + match.Groups["sure6"].Value + ":" + match.Groups["sure7"].Value + "," + match.Groups["sure8"].Value;
                    SubtitleList.Add(new Subtitle { DoubleLine = 0, Divergent = 0, Syncronized = false, SubColor = 10, SubNumber = Convert.ToInt32(match.Groups["sira"].Value), SubTimeText = subSureMetin, SubContent = match.Groups["metin"].Value, SubTimeStart = Convert.ToInt32(subSureStart), SubTimeEnd = Convert.ToInt32(subSureEnd) });

                }
                FillDatas();

            }
        }

        ///////////////////////////////////////////////////////    v v v   Fill DataGridView  v v v   ///////////////////////////////////////////////////////
        public void FillDatas()
        {
            SubtitleList = SubtitleList.OrderBy(o => o.SubTimeText).ToList();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("No", typeof(int));
            dataTable.Columns.Add("Time", typeof(string));
            dataTable.Columns.Add("Content", typeof(string));
            dataTable.Columns.Add("Voice", typeof(int));
            for (int i = 0; i < SubtitleList.Count; i++)
            {
                dataTable.Rows.Add(i + 1, SubtitleList[i].SubTimeText, SubtitleList[i].SubContent, SubtitleList[i].SubColor);

            }

            dataGridView.DataSource = dataTable;
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

       
    }
    //Incoming Subtitle Class
    public class Subtitle
    {
        public int SubNumber;
        public string? SubTimeText;
        public double SubTimeStart;
        public double SubTimeEnd;
        public string? SubContent;
        public int SubColor;
        //Sync
        public bool Syncronized;
        public int Divergent;
        public int DoubleLine;
    }
}


