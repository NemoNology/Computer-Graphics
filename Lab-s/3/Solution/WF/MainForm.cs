using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace WF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            _mainView.Image = _bmp;

            b_color.BackColor = _color;
            b_color.ForeColor = InverseColor(_color);

            ColorSelect.OnColorCahnged += ColorChanged;
        }



        private bool _isChosingCP;
        private Color _color = Color.Black;

        private Bitmap _bmp = new Bitmap(100, 60);
        private Graphics _g;

        private ColorSelect _colorSelection;


        private void MainView_Paint(object sender, PaintEventArgs e)
        {
            //_g.DrawRectangle()
        }

        #region Features

        private void ColorChanged(Color color)
        {
            _color = color;
            b_color.Text = color.Name;
            b_color.BackColor = color;
            b_color.ForeColor = InverseColor(color);
        }

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

        private void b_color_Click(object sender, EventArgs e)
        {
            if (_colorSelection == null || _colorSelection.IsDisposed)
            {
                _colorSelection = new ColorSelect(_color);
            }

            _colorSelection?.Show();
        }

        private void b_chooseCP_MouseDown(object sender, MouseEventArgs e)
        {
            _isChosingCP = true;
        }

        public static Color InverseColor(Color color)
        {
            return Color.FromArgb(~color.ToArgb());
        }

        #endregion
    }
}
