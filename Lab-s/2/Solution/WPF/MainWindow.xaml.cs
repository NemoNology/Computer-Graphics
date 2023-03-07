using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            _bs = new WriteableBitmap(PixelWidth, PixelHeight, 
                96, 96, 
                PixelFormats.Rgb24, BitmapPalettes.Halftone27);
            l_pixelSize.Content = $"{PixelWidth} x {PixelHeight}";
        }

        private const int PixelWidth = 100;
        private const int PixelHeight = 60;
        private BitmapSource? _bs;

        private void ButtonDraw_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}