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
            PictureRotate.OnImageRotate += MainView_Rotate;

            _mainView.Image = new Bitmap(_mainView.Width, _mainView.Height);

            _centralPoint = new Point(
                (int)_mainView.Width / 2,
                _mainView.Height / 2);

            ChangeInfo();

            _g = Graphics.FromImage(_mainView.Image);

            _pen = new Pen(_color, 3f);

            DrawCentralPoint(this, EventArgs.Empty);

            saveFileDialog.Filter = openFileDialog.Filter = "PNG files (*.png)|*.png";
        }

        public static event EventHandler? OnMainViewResize;

        private bool _isChosingCP;
        private Color _color = Color.Black;
        private Pen _pen;
        private Point _firstLinePoint;

        private Point _centralPoint;
        private Graphics _g;

        private ColorSelect? _colorSelection;
        private PictureResize? _pictureResizing;

        public Point MainViewSize => new Point(_mainView.Image.Width, _mainView.Image.Height);


        /// <summary>
        /// MainView Mouse_Move EventHandler - Drawing
        /// </summary>
        private void MainView_Draw(object? sender, MouseEventArgs e)
        {
            _outputMouseCoordinates.Text = $"{e.X}, {e.Y}";

            if (e.Button != MouseButtons.Left) return;

            _g.DrawRectangle(_pen, e.X, e.Y, 1, 1);

            _mainView.Image = (Bitmap)_mainView.Image;
        }

        private void MainView_Rotate(object sender, EventArgs e)
        {
            var angle = (Math.PI / 180) * (int)sender;

            Point[,] newCoordinates = new Point[_mainView.Image.Width, _mainView.Image.Height];

            int minX = 0, minY = 0, maxX = _mainView.Image.Width, maxY = _mainView.Image.Height;

            int X, Y;

            for (int x = 0; x < _mainView.Image.Width; x++)
            {
                for (int y = 0; y < _mainView.Image.Height; y++)
                {
                    X = (int)Math.Round(
                        (x - _centralPoint.X) * Math.Cos(angle) -
                        (y - _centralPoint.Y) * Math.Sin(angle) + _centralPoint.X,
                        MidpointRounding.AwayFromZero);

                    Y = (int)Math.Round(
                        (x - _centralPoint.X) * Math.Sin(angle) +
                        (y - _centralPoint.Y) * Math.Cos(angle) + _centralPoint.Y,
                        MidpointRounding.AwayFromZero);

                    newCoordinates[x, y] = new Point((int)X, (int)Y);

                    if (X < minX) minX = X;
                    if (X > maxX) maxX = X;

                    if (Y < minY) minY = Y;
                    if (Y > maxY) maxY = Y;
                }
            }

            Bitmap newImage = new Bitmap(maxX - minX, maxY - minY);

            _centralPoint = new Point(
                _centralPoint.X * newImage.Width / _mainView.Image.Width,
                _centralPoint.Y * newImage.Height / _mainView.Image.Height);


            for (int x = 0; x < _mainView.Image.Width; x++)
            {
                for (int y = 0; y < _mainView.Image.Height; y++)
                {

                }
            }
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

            OnMainViewResize?.Invoke(newSize, EventArgs.Empty);
        }

        private void MainView_LineDrawStart(object sender, MouseEventArgs e)
        {
            if (_isChosingCP)
            {
                DrawCentralPoint(true, EventArgs.Empty);

                _centralPoint = e.Location;

                DrawCentralPoint(this, EventArgs.Empty);

                ChangeInfo();

                _isChosingCP = false;
            }

            if (e.Button == MouseButtons.Right)
            {
                _firstLinePoint = e.Location;
            }
        }

        private void MainView_LineDrawEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !_firstLinePoint.IsEmpty)
            {
                _g.DrawLine(_pen, _firstLinePoint, e.Location);

                _mainView.Image = (Bitmap)_mainView.Image;
            }
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

        private void DrawCentralPoint(object sender, EventArgs e)
        {
            _g.DrawEllipse(new Pen(sender.GetType() == typeof(bool) ?
                Color.DarkOliveGreen : Color.DarkMagenta,
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

        private void ImageClear_Click(object sender, EventArgs e)
        {
            _mainView.Image = new Bitmap(_mainView.Image.Width, _mainView.Image.Height);

            _g = Graphics.FromImage(_mainView.Image);

            DrawCentralPoint(this, EventArgs.Empty);
        }

        #endregion
    }
}