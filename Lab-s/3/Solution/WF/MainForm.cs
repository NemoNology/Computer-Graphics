using System.Drawing;

namespace WF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        #region Features


        private void b_chooseCP_MouseEnter(object sender, EventArgs e)
        {
            var font = ((ToolStripStatusLabel)sender).Font;

            ((ToolStripStatusLabel)sender).Font = new Font(font, FontStyle.Bold);
        }

        private void b_chooseCP_MouseLeave(object sender, EventArgs e)
        {
            var font = ((ToolStripStatusLabel)sender).Font;

            ((ToolStripStatusLabel)sender).Font = new Font(font, FontStyle.Regular);
        }


        #endregion
    }
}
