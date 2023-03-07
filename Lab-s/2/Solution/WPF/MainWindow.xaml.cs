using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;

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
            l_pixelSize.Content = $"{PixelWidth} x {PixelHeight}";
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

            DrawPixel(ref bmp, x, y, colorEllipseCenter, px);

            MainView.Source = BitmapToImageSource(bmp);

        }

        private void DrawEllipse(ref Bitmap bmp,
            int x, int y, int width, int height, int pixelSize, Color drawColor)
        {
            width = (int) Math.Round((double)width / 2, MidpointRounding.AwayFromZero);
            height = (int) Math.Round((double)height / 2, MidpointRounding.AwayFromZero);

            int d = 0;
            int u = 12 * height;
            int v = 12 * height + 8 * width;
            int L = width * height;

            int X = x, Y = y - height / 2;

            while (L > 0)
            {
                DrawPixel(ref bmp, X, Y, drawColor, pixelSize, 
                    new Point(x, y), 
                    true, true);
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

        private void DrawPixel(ref Bitmap bmp, int x, int y, Color color, int pixelSize = 1, 
            System.Drawing.Point inversionCenter = new System.Drawing.Point(), 
            bool inversionY = false, bool inversionX = false)
        {
            int px = (int)Math.Round((double)pixelSize / 2, MidpointRounding.AwayFromZero);
            
            for (int i = y - pixelSize / 2; i < y + px; i++)
            {
                for (int j = x - pixelSize / 2; j < x + px; j++)
                {
                    if (i >= 0 && i < bmp.Height && j >= 0 && j < bmp.Width)
                    {
                        bmp.SetPixel(j, i, color);
                    }
                    
                    
                    if (inversionY)
                    {
                        int dX = Math.Abs(inversionCenter.X - j);
                        int iX = inversionCenter.X + (inversionCenter.X < j ? -dX : dX);

                        DrawPixel(ref bmp, iX, i, color);
                    }
                    
                    if (inversionX)
                    {
                        int dY = Math.Abs(inversionCenter.Y - i);
                        int iY = inversionCenter.Y + (inversionCenter.Y < i ? -dY : dY);

                        DrawPixel(ref bmp, j, iY, color, 1, inversionCenter, inversionY);
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