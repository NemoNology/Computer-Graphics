using System.Drawing.Imaging;
using System.Numerics;

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
                _mainView.Image.Width / 2,
                _mainView.Image.Height / 2);

            ChangeInfo();

            _g = Graphics.FromImage(_mainView.Image);

            _pen = new Pen(_color);

            saveFileDialog.Filter = openFileDialog.Filter = "PNG files (*.png)|*.png";
        }

        public static event EventHandler? OnMainViewResize;

        private bool _isChosingCP;
        private Color _color = Color.Black;
        private Pen _pen;
        private Point _firstLinePoint;

        private Point _centralPoint;
        private Color _centralPointColor;
        private Graphics _g;

        private ColorSelect? _colorSelection;
        private PictureResize? _pictureResizing;
        private PictureRotate? _pictureRotating;

        private List<Vector4> _lines = new List<Vector4>();
        private List<Point> _pixels = new List<Point>();

        /// <summary>
        /// MainView Mouse_Move EventHandler - Drawing
        /// </summary>
        private void MainView_Draw(object? sender, MouseEventArgs e)
        {
            _outputMouseCoordinates.Text = $"{e.X}, {e.Y}";

            if (e.Button != MouseButtons.Left ||
                _isChosingCP ||  
                _pixels.Contains(e.Location)) return;
                
            _pixels.Add(e.Location);

            DrawPixels(true);
        }

        private void MainView_Rotate(object sender)
        {
            var angle = (Math.PI / 180) * (int)sender;

            int oW = _mainView.Image.Width;
            int oH = _mainView.Image.Height;

            (double csin, double ccos) = Math.SinCos(angle);

            int minX = 0, minY = 0;
            int maxX = oW - 1, maxY = oH - 1;

            if (_pixels != null && _pixels.Count != 0)
            {
                for (int i = 0; i < _pixels.Count; i++)
                {
                    var X = (int)Math.Round(
                        (_pixels[i].X - _centralPoint.X) * ccos -
                        (_pixels[i].Y - _centralPoint.Y) * csin + _centralPoint.X,
                        MidpointRounding.AwayFromZero);

                    var Y = (int)Math.Round(
                        (_pixels[i].X - _centralPoint.X) * csin +
                        (_pixels[i].Y - _centralPoint.Y) * ccos + _centralPoint.Y,
                        MidpointRounding.AwayFromZero);

                    _pixels[i] = new Point(X, Y);

                    if (X > maxX) maxX = X;
                    if (Y > maxY) maxY = Y;

                    if (X < minX) minX = X;
                    if (Y < minY) minY = Y;
                }
            }

            if (_lines != null && _lines.Count != 0)
            {
                for (int i = 0; i < _lines.Count; i++)
                {
                    var X = (int)Math.Round(
                        (_lines[i].X - _centralPoint.X) * ccos -
                        (_lines[i].Y - _centralPoint.Y) * csin + _centralPoint.X,
                        MidpointRounding.AwayFromZero);

                    var Y = (int)Math.Round(
                        (_lines[i].X - _centralPoint.X) * csin +
                        (_lines[i].Y - _centralPoint.Y) * ccos + _centralPoint.Y,
                        MidpointRounding.AwayFromZero);

                    var Z = (int)Math.Round(
                        (_lines[i].Z - _centralPoint.X) * ccos -
                        (_lines[i].W - _centralPoint.Y) * csin + _centralPoint.X,
                        MidpointRounding.AwayFromZero);

                    var W = (int)Math.Round(
                        (_lines[i].Z - _centralPoint.X) * csin +
                        (_lines[i].W - _centralPoint.Y) * ccos + _centralPoint.Y,
                        MidpointRounding.AwayFromZero);

                    _lines[i] = new Vector4(
                        _lines[i].X,
                        _lines[i].Y,
                        _lines[i].Z,
                        _lines[i].W);

                    if (X > maxX) maxX = X;
                    if (Y > maxY) maxY = Y;

                    if (X < minX) minX = X;
                    if (Y < minY) minY = Y;

                    if (Z > maxX) maxX = Z;
                    if (W > maxY) maxY = W;

                    if (Z < minX) minX = Z;
                    if (W < minY) minY = W;
                }
            }

            Point newSize = new Point(
                Diff(_centralPoint.X, minX) + Diff(_centralPoint.X, maxX) + 1,
                Diff(_centralPoint.Y, minY) + Diff(_centralPoint.Y, maxY) + 1);

            int nW = newSize.X >= oW ? newSize.X : oW;
            int nH = newSize.Y >= oH ? newSize.Y : oH;

            _mainView.Image = new Bitmap(nW, nH);

            int dX = minX <= 0 ? -minX : -maxX;
            int dY = minY <= 0 ? -minY : -maxY;

            if (_pixels != null && _pixels.Count != 0)
            {
                for (int i = 0; i < _pixels.Count; i++)
                {
                    _pixels[i] = new Point(
                        _pixels[i].X + dX,
                        _pixels[i].Y + dY);
                }
            }

            if (_lines != null && _lines.Count != 0)
            {
                for (int i = 0; i < _lines.Count; i++)
                {
                    _lines[i] = new Vector4(
                        _lines[i].X + dX,
                        _lines[i].Y + dY,
                        _lines[i].Z + dX,
                        _lines[i].W + dY);
                }
            }

            _centralPoint = new Point(
                (int)Math.Round(_centralPoint.X * ((float)nW / oW), MidpointRounding.AwayFromZero),
                (int)Math.Round(_centralPoint.Y * ((float)nH / oH), MidpointRounding.AwayFromZero));

            ChangeInfo();
            Redraw();

            if (_pictureResizing != null && !_pictureResizing.IsDisposed)
            {
                OnMainViewResize?.Invoke(new Point(nW, nH), EventArgs.Empty);
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

            if (_lines != null && _lines.Count != 0)
            {
                for (int i = 0; i < _lines.Count; i++)
                {
                    _lines[i] = new Vector4(
                        _lines[i].X * kX,
                        _lines[i].Y * kY,
                        _lines[i].Z * kX,
                        _lines[i].W * kY);
                }
            }

            if (_pixels != null && _pixels.Count != 0)
            {
                for (int i = 0; i < _pixels.Count; i++)
                {
                    _pixels[i] = new Point(
                        (int)(_pixels[i].X * kX),
                        (int)(_pixels[i].Y * kY));
                }
            }

            _mainView.Image = new Bitmap(newSize.X, newSize.Y);

            Redraw();

            _centralPoint = new Point(
                (int)(_centralPoint.X * kX),
                (int)(_centralPoint.Y * kY));

            ChangeInfo();

            OnMainViewResize?.Invoke(newSize, EventArgs.Empty);
        }

        private void MainView_LineDrawStart(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Left)
            {
                if (_isChosingCP)
                {
                    _centralPoint = e.Location;
                    ChangeInfo();
                    _isChosingCP = false;
                    return;
                }

                if (!_pixels.Contains(e.Location))
                {
                    _pixels.Add(e.Location);
                    DrawPixels(true);
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                _firstLinePoint = e.Location;
            }
        }

        private void MainView_LineDrawEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right 
                && !_firstLinePoint.IsEmpty)
            {
                var buff = new Vector4(
                    _firstLinePoint.X,
                    _firstLinePoint.Y,
                    e.X >= _mainView.Image.Width ? _mainView.Image.Width - 1 : e.X,
                    e.Y >= _mainView.Image.Height ? _mainView.Image.Height - 1 : e.Y);

                if (_lines.Contains(buff)) return;

                _lines.Add(buff);

                DrawLines(true);
            }
        }


        #region Features

        /// <summary>
        /// Draw all saved pixels on main view
        /// </summary>
        /// <param name="DrawOnlyLastLine"> If true: draw only last line </param>
        private void DrawLines(bool DrawOnlyLastLine = false)
        {
            if (_lines == null || _lines.Count == 0) return;

            Vector4 l = _lines.Last();
            Point p1, p2;

            if (DrawOnlyLastLine)
            {
                p1 = new Point((int)l.X, (int)l.Y);
                p2 = new Point((int)l.Z, (int)l.W);

                _g.DrawLine(_pen, p1, p2);
                Redraw(true);

                return;
            }

            foreach (var line in _lines)
            {
                p1 = new Point((int)line.X, (int)line.Y);
                p2 = new Point((int)line.Z, (int)line.W);

                _g.DrawLine(_pen, p1, p2);
            }
        }

        /// <summary>
        /// Draw all saved pixels on main view
        /// </summary>
        /// <param name="DrawOnlyLastPixel"> If true: draw only last pixel </param>
        private void DrawPixels(bool DrawOnlyLastPixel = false)
        {
            if (_pixels == null || _pixels.Count == 0) return;

            Point lp = _pixels.Last();

            if (DrawOnlyLastPixel)
            {
                _g.DrawRectangle(_pen,
                    lp.X, lp.Y,
                    1, 1);
                Redraw(true);

                return;
            }

            foreach (var p in _pixels)
            {
                _g.DrawRectangle(_pen, p.X, p.Y, 1, 1);
            }
        }

        private int Diff(int a, int b) => Math.Abs(a - b);

        private void ImageResize_Click(object sender, EventArgs e)
        {
            if (_pictureResizing == null || _pictureResizing.IsDisposed)
            {
                _pictureResizing = new PictureResize(new Point(
                    _mainView.Width, _mainView.Height));
            }

            _pictureResizing?.Show();
        }

        private void ShowCentralPoint(object sender, EventArgs e)
        {
            _centralPointColor = ((Bitmap)_mainView.Image).GetPixel(
                _centralPoint.X, _centralPoint.Y);

            _g.DrawRectangle(new Pen(Color.FromArgb(
                ~_centralPointColor.ToArgb())),
                _centralPoint.X, _centralPoint.Y,
                1, 1);

            Redraw(true);
        }

        private void HideCentralPoint(object sender, EventArgs e)
        {
            _g.DrawRectangle(new Pen(Color.FromArgb(
                _centralPointColor.ToArgb())),
                _centralPoint.X, _centralPoint.Y,
                1, 1);

            Redraw(true);
        }

        private void Redraw(bool OnlyUpdateImage = false)
        {
            if (OnlyUpdateImage)
            {
                _mainView.Image = (Bitmap)_mainView.Image;
                return;
            }

            _mainView.Image = new Bitmap(_mainView.Image.Width, _mainView.Image.Height);

            _g = Graphics.FromImage(_mainView.Image);

            DrawLines();
            DrawPixels();

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
            _pixels.Clear();
            _lines.Clear();

            Redraw();
        }

        private void ImageRotate_Click(object sender, EventArgs e)
        {
            if (_pictureRotating == null || _pictureRotating.IsDisposed)
            {
                _pictureRotating = new PictureRotate();
            }

            _pictureRotating.Show();
        }


        #endregion
    }
}