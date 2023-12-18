namespace Subtitle_Handler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void closeAppBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minAppBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
