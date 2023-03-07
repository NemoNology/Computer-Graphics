using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            bmp = new Bitmap(PixelWidth, PixelHeight);
            ClearBitmap(ref bmp, colorEmpty);
            MainView.Source = BitmapToImageSource(bmp);
            inputX.Text = ((bmp.Width - 1) / 2).ToString();
            inputY.Text = ((bmp.Height - 1) / 2).ToString();
            inputWidth.Text = (bmp.Width / 3).ToString();
            inputHeight.Text = (bmp.Height / 3).ToString();
        }

        private const int PixelWidth = 100;
        private const int PixelHeight = 60;
        private Bitmap bmp;

        private Color colorEllipseBorder = Color.Black;
        private Color colorEllipseCenter = Color.DarkMagenta;
        private Color colorEmpty = Color.White;

        // TODO: Complete Ellipse draw

        private void ButtonDrawEllipse_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput())
            {
                return;
            }

            int x = Convert.ToInt32(inputX.Text);
            int y = Convert.ToInt32(inputY.Text);
            int w = Convert.ToInt32(inputWidth.Text);
            int h = Convert.ToInt32(inputHeight.Text);
            int px = Convert.ToInt32(inputDrawPixelSize.Text);


            ClearBitmap(ref bmp, colorEmpty);

            DrawEllipse(ref bmp, x, y, w, h, px, colorEllipseBorder);

            DrawPixel(ref bmp, x, y, px, colorEllipseCenter);

            MainView.Source = BitmapToImageSource(bmp);

        }

        private void ButtonDrawCircle_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValidInput())
            {
                return;
            }

            int x = Convert.ToInt32(inputX.Text);
            int y = Convert.ToInt32(inputY.Text);
            int r = Convert.ToInt32(inputWidth.Text);
            int px = Convert.ToInt32(inputDrawPixelSize.Text);


            ClearBitmap(ref bmp, colorEmpty);

            DrawCircle(ref bmp, x, y, r, px, colorEllipseBorder);

            DrawPixel(ref bmp, x, y, px, colorEllipseCenter);

            MainView.Source = BitmapToImageSource(bmp);
        }

        private void DrawCircle(ref Bitmap bmp,
            int x, int y, int radius, int pixelSize, Color drawColor)
        {
            int X = x, Y = y - radius / 2;

            int d = 3 - 2 * radius;
            int u = 6;
            int v = 10 - 4 * radius;

            while (v < 10)
            {
                DrawPixel(ref bmp, X, Y, pixelSize, drawColor, 
                    new System.Drawing.Point(x, y), 
                    true, true);
                X++;

                u += 4;

                if (d < 0)
                {
                    d += u;
                    v += 4;
                }
                else
                {
                    d += v;
                    v += 8;

                    Y++;
                }
            }

        }



        private void DrawEllipse(ref Bitmap bmp,
            int x, int y, int width, int height, int pixelSize, Color drawColor)
        {
            width /= 2;
            height /= 2;

            int d = 0;
            int u = 12 * height;
            int v = 12 * height + 8 * width;
            int L = width * height;

            int X = x, Y = y - height / 2;

            while (L > 0)
            {
                DrawPixel(ref bmp, X, Y, pixelSize, drawColor);
                X++;


                u += 8 * height;

                if (d < 0)
                {
                    d += u;
                    v += 8 * width;
                    L -= height;
                }
                else
                {
                    d += v;
                    v += 8 * (height + width);
                    L -= (width + height);

                    Y++;
                }
            }
        }

        #region Features

        private void ClearBitmap(ref Bitmap bmp, Color color)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    bmp.SetPixel(j, i, color);
                }
            }
        }

        private void DrawPixel(ref Bitmap bmp, int x, int y, int pixelSize, Color color, 
            System.Drawing.Point inversionCenter = new System.Drawing.Point(), 
            bool inversionY = false, bool inversionX = false)
        {
            int endY = pixelSize == 1 ? y + 1 : y + pixelSize / 2;
            int endX = pixelSize == 1 ? x + 1 : x + pixelSize / 2;

            for (int i = y - pixelSize / 2; i < endY; i++)
            {
                for (int j = x - pixelSize / 2; j < endX; j++)
                {
                    if (i >= 0 && i < bmp.Height && j >= 0 && j < bmp.Width)
                    {
                        bmp.SetPixel(j, i, color);
                    }

                        // TODO: Fixe inversion

                    if (inversionY)
                    {
                        int dX = Math.Abs(inversionCenter.X - j);
                        int iX = inversionCenter.X + (inversionCenter.X < j ? -dX : dX);

                        DrawPixel(ref bmp, iX, i, pixelSize, color);
                    }
                    if (inversionX)
                    {
                        int dY = Math.Abs(inversionCenter.Y - i);
                        int iY = inversionCenter.Y + (inversionCenter.Y < i ? -dY : dY);

                        DrawPixel(ref bmp, j, iY, pixelSize, color, inversionCenter, inversionY);
                    }
                }
            }
        }

        private bool IsValidInput()
        {
            try
            {
                status.Content = "Invalid Data: Pixel Draw Size";
                Convert.ToUInt32(inputDrawPixelSize.Text);
                status.Content = "Invalid Data: X coordinate";
                Convert.ToUInt32(inputX.Text);
                status.Content = "Invalid Data: Y coordinate";
                Convert.ToUInt32(inputY.Text);
                status.Content = "Invalid Data: Width";
                Convert.ToUInt32(inputWidth.Text);
                status.Content = "Invalid Data: Height";
                Convert.ToUInt32(inputHeight.Text);

                status.Content = "...";
                return true;
            }
            catch
            {
                return false;
            }
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
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