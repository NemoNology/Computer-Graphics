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
            _bmp = new Bitmap(PixelWidth, PixelHeight);
            ClearBitmap(ref _bmp, _colorEmpty);
            MainView.Source = BitmapToImageSource(_bmp);
            InputX.Text = ((_bmp.Width - 1) / 2).ToString();
            InputY.Text = ((_bmp.Height - 1) / 2).ToString();
            InputWidth.Text = (_bmp.Width / 3).ToString();
            InputHeight.Text = (_bmp.Height / 3).ToString();
            PixelSize.Content = $"{PixelWidth} x {PixelHeight}";
        }

        private const int PixelWidth = 100;
        private const int PixelHeight = 60;
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


            ClearBitmap(ref _bmp, _colorEmpty);

            DrawEllipse(ref _bmp, 
                new Point(x, y), 
                w, h, 
                _colorEllipseBorder, px);

            DrawPixel(ref _bmp, x, y, _colorEllipseCenter, px);

            MainView.Source = BitmapToImageSource(_bmp);
        }

        private void DrawEllipse(ref Bitmap canvas,
            Point ellipseCenter, int width, int height, Color drawColor, int pixelSize = 1)
        {
            int a = (int) Math.Round(width * 0.5, MidpointRounding.AwayFromZero);
            int b = (int) Math.Round(height * 0.5, MidpointRounding.AwayFromZero);

            
            // Start point = (x, y + height / 2)
            int x = ellipseCenter.X, y = ellipseCenter.Y + b;
            
            var a2 = a * a;
            var b2 = b * b;
            
            // Delta is d
            // d(x, y) = 4 * b^2 * (x+1)^2 + a^2 * (2y-1)^2 - 4 * a^2 * b^2
            var d = 4 * b2 * Math.Pow(x + 1, 2) + 
                       a2 * Math.Pow(2 * y - 1, 2) -
                       4 * a2 * b2;
            
            // Draw horizontal part of arc
            // End horizontal path point coordinates
            // is point where b^2 * x = a^2 * y;   
            while (b2 * x != a2 * y)
            {
                DrawPixelWithInversion(ref canvas, x, y, 
                    drawColor, pixelSize, 
                    new Point(x, y), 
                    true, true);

                // Algorithm always move right
                // so we can take out step to right
                x++;

                if (d < 0)
                {
                    // d(x + 1, y) - Horizontal step - Move right
                    // d = d + 4 * b^2 * (2x+3)
                    d += 4 * b2 * (2 * x + 3);
                }
                else
                {
                    // d(x + 1, y + 1) - Diagonal step - Move right and down
                    // d = d + 4 * b^2 * (2x+3) - 8 * a^2 * (y-1) 
                    d += 4 * b2 * (2 * x + 3) - 
                        8 * a2 * (y - 1);
                    
                    y--;
                }
            }
            
            // d(x, y) = b^2 * (2x+1)^2 + 4 * a^2 * (y+1)^2 - 4 * a^2 * b^2
            d = b2 * Math.Pow(2 * x + 1, 2) + 
                4 * a2 * Math.Pow(y + 1, 2) -
                4 * a2 * b2;
            
            // Draw vertical part
            // Vertical part end is place where y = centerEllipse.Y
            while (y != ellipseCenter.Y)
            {
                DrawPixel(ref canvas, x, y, drawColor, pixelSize);
                
                // Algorithm always move down
                // so we can take out step to down 
                y--;

                if (d < 0)
                {
                    // d(x, y - 1) - Vertical step - Move down
                    // d = d + 4 * a^2 * (2y + 3)
                    d += 4 * a2 * (2 * y + 3);
                }
                else
                {
                    // d(x + 1, y - 1) - Diagonal step - Move down and right
                    // d = d + 4 * a^2 * (2y + 3) - 8 * b^2 * (x + 1)
                    d += 4 * a2 * (2 * y + 3) - 
                         8 * b2 * (x + 1);
                    
                    x++;
                }
            }
        }
        

        #region Features

        public void ClearBitmap(ref Bitmap canvas, Color color)
        {
            for (int i = 0; i < canvas.Height; i++)
            {
                for (int j = 0; j < canvas.Width; j++)
                {
                    canvas.SetPixel(j, i, color);
                }
            }
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