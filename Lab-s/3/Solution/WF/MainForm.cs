using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WF
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            b_chooseColor.BackColor = _color;
            b_chooseColor.ForeColor = InverseColor(_color);

            ColorSelect.OnColorChanged += ColorChanged;
            PictureResize.OnPictureSizeChanged += MainView_Resize;

            _mainView.Image = new Bitmap(_mainView.Width, _mainView.Height);

            _centralPoint = new Point(
                (int)_mainView.Width / 2,
                _mainView.Height / 2);

            ChangeInfo();

            _g = Graphics.FromImage(_mainView.Image);

            _pen = new Pen(_color, 3f);

            DrawCentralPoint(null, null);

            saveFileDialog.Filter = openFileDialog.Filter = "PNG files (*.png)|*.png";
        }

        private bool _isChosingCP;
        private Color _color = Color.Black;
        private Pen _pen;

        private Point _centralPoint;
        private Graphics _g;

        private ColorSelect? _colorSelection;
        private PictureResize? _pictureResizing;


        /// <summary>
        /// MainView Mouse_Move EventHandler - Drawing
        /// </summary>
        private void MainView_Draw(object sender, MouseEventArgs e)
        {
            _outputMouseCoordinates.Text = $"{e.X}, {e.Y}";

            if (e.Button != MouseButtons.Left) return;

            _g.DrawRectangle(_pen, e.X, e.Y, 1, 1);

            _mainView.Image = (Bitmap)_mainView.Image;
        }

        private void MainView_Resize(Point newSize)
        {
            if (newSize.X > this.Width)
            {
                newSize = new Point(this.Width, newSize.Y);
            }

            if (newSize.Y > (this.Height - statusStrip1.Height - menuStrip1.Height))
            {
                newSize = new Point(newSize.X,
                    this.Height - statusStrip1.Height - menuStrip1.Height);
            }

            var kX = (float)newSize.X / _mainView.Width;
            var kY = (float)newSize.Y / _mainView.Height;

            var oldImage = (Bitmap)_mainView.Image;

            var newImage = new Bitmap(newSize.X, newSize.Y);

            var g = Graphics.FromImage(newImage);

            SolidBrush brush = new SolidBrush(Color.Black);

            for (int i = 0; i < oldImage.Width; i++)
            {
                for (int j = 0; j < oldImage.Height; j++)
                {
                    brush.Color = oldImage.GetPixel(i, j);

                    g.FillRectangle(brush,
                        i * kX, j * kY,
                        kX, kY);
                }
            }

            _mainView.Image = newImage;

            _mainView.Image = (Bitmap)_mainView.Image;

            _g = Graphics.FromImage(_mainView.Image);

            _centralPoint = new Point(
                (int)(_centralPoint.X * kX),
                (int)(_centralPoint.Y * kY));

            ChangeInfo();
        }


        #region Features


        private void ImageResize_Click(object sender, EventArgs e)
        {
            if (_pictureResizing == null || _pictureResizing.IsDisposed)
            {
                _pictureResizing = new PictureResize(new Point(
                    _mainView.Width, _mainView.Height));
            }

            _pictureResizing?.Show();
        }

        private void DrawCentralPoint(object? sender, EventArgs? e)
        {
            _g.DrawEllipse(new Pen(Color.DarkMagenta,
                    5f),
                    _centralPoint.X, _centralPoint.Y,
                    5, 5);

            _mainView.Image = (Bitmap)_mainView.Image;
        }

        private void ColorChanged(Color color)
        {
            _color = color;
            b_chooseColor.Text = color.Name;
            b_chooseColor.BackColor = color;
            b_chooseColor.ForeColor = InverseColor(color);

            _pen.Color = color;
        }

        private void ChangeInfo()
        {
            _outputPictureSize.Text = $"{_mainView.Image.Width} x {_mainView.Image.Height} (px)";
            _outputCentralPointCoordinates.Text = $"{_centralPoint.X}, {_centralPoint.Y}";
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

        private void ImageSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _mainView.Image.Save(saveFileDialog.FileName,
                    ImageFormat.Png);
            }
        }

        private void ImageLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _mainView.Image = new Bitmap(openFileDialog.FileName);

                _g = Graphics.FromImage(_mainView.Image);
            }
        }

        private void MainView_MouseLeave(object sender, EventArgs e)
        {
            _outputMouseCoordinates.Text = "...";
        }

        private void MainView_Move(object sender, EventArgs e)
        {
            _g = Graphics.FromImage(((PictureBox)sender).Image);
        }


        #endregion
    }
}
