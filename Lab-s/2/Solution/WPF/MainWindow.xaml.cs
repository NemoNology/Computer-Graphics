using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

using Color = System.Drawing.Color;
using Point = System.Drawing.Point;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Bitmap _bmp;

        private readonly Color _colorEllipseBorder = Color.Black;
        private readonly Color _colorEllipseCenter = Color.DarkMagenta;
        private readonly Color _colorEmpty = Color.White;

        private void ButtonDrawEllipse_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput())
            {
                return;
            }

            int x = Convert.ToInt32(InputX.Text);
            int y = Convert.ToInt32(InputY.Text);
            int w = Convert.ToInt32(InputWidth.Text);
            int h = Convert.ToInt32(InputHeight.Text);
            int px = Convert.ToInt32(InputDrawPixelSize.Text);
            
            _bmp = ClearedBitmap(w * 2, h * 2, _colorEmpty);

            DrawEllipse(ref _bmp, 
                new Point(x, y), 
                w, h, 
                _colorEllipseBorder, px);

            DrawPixel(ref _bmp, x, y, _colorEllipseCenter, px);

            MainView.Source = BitmapToImageSource(_bmp);
        }

        /// <summary>
        /// Algorithm was created by John Kennedy<br/>
        /// https://web.archive.org/web/20120225095359/http://homepage.smc.edu/kennedy_john/belipse.pdf
        /// </summary>
        private void DrawEllipse(ref Bitmap canvas,
            Point ellipseCenter, int width, int height, Color drawColor, int pixelSize = 1)
        {
            int a = (int) Math.Round(width * 0.5, MidpointRounding.AwayFromZero);
            int b = (int) Math.Round(height * 0.5, MidpointRounding.AwayFromZero);
            
            // Start point = (x, y - height / 2)
            int x = ellipseCenter.X + a;
            int y = ellipseCenter.Y;
            
            // a22 = 2 * a^2; b22 = 2 * b^2
            var a22 = 2 * a * a;
            var b22 = 2 * b * b;

            var dX = b * b * (1 - 2 * a);
            var dY = a * a;
            var ellipseError = 0;

            var endX = b22 * a;
            var endY = ellipseCenter.Y;

            // 1st set of points, y > 1
            while (endX >= endY)
            {
                DrawPixelWithInversion(ref canvas, x, y, 
                    drawColor, pixelSize, 
                    new Point(ellipseCenter.X, ellipseCenter.Y), 
                    true, true);

                y++;
                endY += a22;
                ellipseError += dY;
                dY += a22;

                if (2 * ellipseError + dX > 0)
                {
                    x--;
                    endX -= b22;
                    ellipseError += dX;
                    dX += b22;
                }
            }

            x = ellipseCenter.X;
            y = ellipseCenter.Y - b;

            dX = b * b;
            dY = a * a * (1 - 2 * b);
            ellipseError = 0;
            endX = 0;
            endY = a22 * b;

            // 2nd set of points, y < -1
            while (endX <= endY)
            {
                DrawPixelWithInversion(ref canvas, x, y, 
                    drawColor, pixelSize, 
                    new Point(ellipseCenter.X, ellipseCenter.Y), 
                    true, true);

                x++;
                endX += b22;
                ellipseError += dX;
                dX += b22;

                if (2 * ellipseError + dY > 0)
                {
                    y++;
                    endY -= a22;
                    ellipseError += dY;
                    dY += a22;
                }
            }
        }
        
        #region Features

        public Bitmap ClearedBitmap(int width, int height, Color color)
        {
            Bitmap bmp = new Bitmap(width, height);
            
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    bmp.SetPixel(j, i, color);
                }
            }

            return bmp;
        }

        public void DrawPixel(ref Bitmap canvas, int x, int y, Color color, int pixelSize = 1)
        {
            int px = (int)Math.Round((double)pixelSize / 2, MidpointRounding.AwayFromZero);
            
            for (int i = y - pixelSize / 2; i < y + px; i++)
            {
                for (int j = x - pixelSize / 2; j < x + px; j++)
                {
                    if (i >= 0 && i < canvas.Height && j >= 0 && j < canvas.Width)
                    {
                        canvas.SetPixel(j, i, color);
                    }
                }
            }
        }

        public void DrawPixelWithInversion(ref Bitmap canvas, int x, int y, 
            Color color, int pixelSize,
            Point inversionCenter, bool inversionOnAxisY, bool inversionOnAxisX = false)
        {
            DrawPixel(ref canvas, x, y, color, pixelSize);
            
            if (inversionOnAxisY)
            {
                int dX = Math.Abs(inversionCenter.X - x);
                int iX = inversionCenter.X + (inversionCenter.X < x ? -dX : dX);

                DrawPixel(ref canvas, iX, y, color, pixelSize);
            }
            
            if (inversionOnAxisX)
            {
                int dY = Math.Abs(inversionCenter.Y - y);
                int iY = inversionCenter.Y + (inversionCenter.Y < y ? -dY : dY);

                DrawPixelWithInversion(ref canvas, x, iY, color, pixelSize, 
                    inversionCenter, inversionOnAxisY);
            }
        }

        private bool IsValidInput()
        {
            try
            {
                Status.Content = "Invalid Data: Pixel Draw Size";
                Convert.ToUInt32(InputDrawPixelSize.Text);
                Status.Content = "Invalid Data: X coordinate";
                Convert.ToUInt32(InputX.Text);
                Status.Content = "Invalid Data: Y coordinate";
                Convert.ToUInt32(InputY.Text);
                Status.Content = "Invalid Data: Width";
                Convert.ToUInt32(InputWidth.Text);
                Status.Content = "Invalid Data: Height";
                Convert.ToUInt32(InputHeight.Text);

                Status.Content = "...";
                return true;
            }
            catch
            {
                return false;
            }
        }

        public BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
        
        #endregion
        
        
    }
}