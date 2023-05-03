using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjectWPF
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

        private void MainView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(mainView);
            var pointsAmount = polygonLines.Points.Count;

            if (e.RightButton == MouseButtonState.Pressed)
            {
                polygonLines.Points.Clear();
                return;
            }

            if (pointsAmount == 0)
            {
                polygonLines.Points.Add(point);
                polygonLines.Points.Add(point);
            }

            polygonLines.Points.Insert(polygonLines.Points.Count - 2, point);
        }

    }
}
