using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Colour = System.Drawing.Color;

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
        }


        const int n = 20;

        

        private void ButtonDraw_Click(object sender, RoutedEventArgs e)
        {
            double x1, y1, x2, y2;

            try
            {
                x1 = Convert.ToDouble(p1_x.Text);
                y1 = Convert.ToDouble(p1_y.Text);

                x2 = Convert.ToDouble(p2_x.Text);
                y2 = Convert.ToDouble(p2_y.Text);
            }
            catch
            {
                MessageBox.Show("Inputed invalid coordinates");
                return;
            }

            var bmp = SetGridOnBitmap(new Bitmap(n + 1, n + 1));

            DDA.Source = null;

            if (Math.Abs(x2 - x1) > Math.Abs(y2 - y1))
            {
                if (x2 - x1 == 0)
                {
                    return;
                }

                double k = (y2 - y1) / (x2 - x1);

                double y = y1;

                if (y2 < y1)
                {
                    y = y2;

                    for (int x = (int)x2; x > (int)x1; x--)
                    {
                        bmp.SetPixel((int)x, (int)y, Colour.Black);
                        y -= k;
                    }
                }
                else
                {
                    for (int x = (int)x1; x <= (int)x2; x++)
                    {
                        bmp.SetPixel((int)x, (int)y, Colour.Black);
                        y += k;
                    }
                }
            }
            else
            {
                if (y2 - y1 == 0)
                {
                    return;
                }

                double k = (x2 - x1) / (y2 - y1);

                double x = x1;

                if (x2 < x1)
                {
                    x = x2;

                    for (int y = (int)y2; y > (int)y1; y--)
                    {
                        bmp.SetPixel((int)x, (int)y, Colour.Black);
                        x -= k;
                    }
                }
                else
                {
                    for (int y = (int)y1; y <= (int)y2; y++)
                    {
                        bmp.SetPixel((int)x, (int)y, Colour.Black);
                        x += k;
                    }
                }
            }

            bmp.SetPixel((int)x1, (int)y1, Colour.DarkCyan);
            bmp.SetPixel((int)x2, (int)y2, Colour.DarkCyan);



            //MainView.BackgroundImage = bmp;
            DDA.Source = Bitmap2BitmapSourse(bmp);
            //MainView.Scale(new SizeF(n, n));
        }

        public Bitmap SetGridOnBitmap(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; i < bmp.Width; i += 2)
                {
                    bmp.SetPixel(i, j, System.Drawing.Color.DimGray);

                    if (bmp.Width <= i)
                    {
                        bmp.SetPixel(i + 1, j, System.Drawing.Color.Gray);
                    }
                }
            }

            return bmp;
        }

        public BitmapSource Bitmap2BitmapSourse(Bitmap bmp)
        {
            var pixels = new int[4 * bmp.Width * bmp.Height];

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; i < bmp.Width; i += 2)
                {
                    pixels[i + bmp.Width + j] = Argb2Bgra(bmp.GetPixel(i, j).ToArgb());
                }
            }

            return BitmapSource.Create(bmp.Width, bmp.Height, 96, 96, System.Windows.Media.PixelFormats.Bgra32, null, pixels, bmp.Width * 4);
        }

        public int Argb2Bgra(int argb)
        {
            var bytes = new byte[4];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(Convert.ToString(argb, 2).ToString().Substring(i * 8, 8), 2);
            }

            Array.Reverse(bytes);

            string result = string.Empty;

            for (int i = 0; i < bytes.Length; i++)
            {
                result += Convert.ToString(bytes[i], 2).PadRight(8, '0');
            }

            return Convert.ToInt32(result, 2);
        }

        public string ReverseString(string str)
        {
            string result = string.Empty;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }

            return result;
        }
    }
}
