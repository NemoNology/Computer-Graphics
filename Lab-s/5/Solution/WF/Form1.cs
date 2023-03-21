using System.Numerics;

namespace WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);

            _g = Graphics.FromImage(outputMainView.Image);
        }


        private Graphics _g;
        private Pen _pen = new Pen(Color.Black);
        private Point _firstLinePoint;

        private List<Vector4> _lines = new List<Vector4>();
        private List<Vector2> _pixels = new List<Vector2>();


        private void ChoseColor_Click(object sender, EventArgs e)
        {
            if (inputColor_Dialog.ShowDialog() == DialogResult.OK)
            {
                _pen.Color = inputColor_Dialog.Color;
            }
        }

        private void MainView_Draw(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_pixels.Contains(new Vector2(e.X, e.Y)))
            {
                _pixels.Add(new Vector2(e.X, e.Y));

                DrawPixels(true);
            }
        }

        private void MainView_LineDrawStart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _g.DrawRectangle(_pen, e.X, e.Y, 0.5f, 0.5f);
            }

            if (e.Button == MouseButtons.Right)
            {
                _firstLinePoint = e.Location;
            }
        }

        private void MainView_LineDrawEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var buff = new Vector4(
                    _firstLinePoint.X,
                    _firstLinePoint.Y,
                    e.X >= outputMainView.Image.Width ? outputMainView.Image.Width - 1 : e.X,
                    e.Y >= outputMainView.Image.Height ? outputMainView.Image.Height - 1 : e.Y);

                if (_lines.Contains(buff)) return;

                _lines.Add(buff);

                DrawLines(true);
            }
        }

        private void MainView_SizeChanged(object sender, EventArgs e)
        {
            var kX = (float)outputMainView.Width / outputMainView.Image.Width;
            var kY = (float)outputMainView.Height / outputMainView.Image.Height;

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
                    _pixels[i] = new Vector2(
                        _pixels[i].X * kX,
                        _pixels[i].Y * kY);
                }
            }

            outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);

            _g = Graphics.FromImage(outputMainView.Image);

            Redraw();
        }

        /// <summary>
        /// Draw all saved pixels on main view
        /// </summary>
        /// <param name="DrawOnlyLastLine"> If true: draw only last line </param>
        private void DrawLines(bool DrawOnlyLastLine = false)
        {
            if (_lines == null || _lines.Count == 0) return;

            Point p1, p2;

            if (DrawOnlyLastLine)
            {
                Vector4 l = _lines.Last();

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

            if (DrawOnlyLastPixel)
            {
                Vector2 p = _pixels.Last();

                _g.DrawRectangle(_pen,
                    p.X, p.Y,
                    1, 1);
                Redraw(true);

                return;
            }

            foreach (var p in _pixels)
            {
                _g.DrawRectangle(_pen, p.X, p.Y, 1, 1);
            }
        }

        private void Redraw(bool OnlyUpdateImage = false)
        {
            if (OnlyUpdateImage)
            {
                outputMainView.Image = (Bitmap)outputMainView.Image;
                return;
            }

            outputMainView.Image = new Bitmap(outputMainView.Image.Width, outputMainView.Image.Height);

            _g = Graphics.FromImage(outputMainView.Image);

            DrawLines();
            DrawPixels();

            outputMainView.Image = (Bitmap)outputMainView.Image;
        }

        private void Image_Clear(object sender, EventArgs e)
        {
            _lines.Clear();
            _pixels.Clear();

            Redraw(); ;
        }
    }
}