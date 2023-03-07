using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF;

public class MainWindowVM
{
    public Image MainView { get; set; }
    
    public string PixelSize
    {
        get
        {
            if (MainView == null || MainView.Source == null)
            {
                return "0 x 0";
            }

            return $"{(MainView.Source as BitmapSource).PixelWidth} x {(MainView.Source as BitmapSource).PixelHeight}";
        }
    }
}