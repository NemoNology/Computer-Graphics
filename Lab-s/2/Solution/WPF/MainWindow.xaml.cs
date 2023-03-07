using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media;
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
            MainView.Source = BitmapToImageSource(bmp);
        }

        private const int PixelWidth = 100;
        private const int PixelHeight = 60;
        private Bitmap bmp;

        private Color colorEllipseBorder = Color.Black;
        private Color colorEllipseCenter = Color.DarkMagenta;

        private void ButtonDraw_Click(object sender, RoutedEventArgs e)
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


            DrawPixel(ref bmp, x, y, px, colorEllipseBorder);

            MainView.Source = BitmapToImageSource(bmp);

        }

        #region Features

        private void DrawPixel(ref Bitmap bmp, int x, int y, int pixelSize, Color color)
        {
            for (int i = y - pixelSize / 2; i < y + pixelSize / 2; i++)
            {
                for (int j = x - pixelSize / 2; j < x + pixelSize / 2; j++)
                {
                    if (i >= 0 && i < bmp.Height && j >= 0 && j < bmp.Width)
                    {
                        bmp.SetPixel(i, j, color);
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