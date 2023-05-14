using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Project
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

        private Bitmap _bmp = new Bitmap(200, 200);

        private void ChangeMainView(Bitmap bmp)
        {
            outputView.Source =
                Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    System.IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
