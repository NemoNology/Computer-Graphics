using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Units;

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

        private async void MainView_MouseDown(object sender, MouseButtonEventArgs e)
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

                return;
            }

            // Checking if this simple polygon
            if (pointsAmount > 3)
            {
                var points = polygonLines.Points;

                var newLinePoint1 = point;
                var newLinePoint2 = 
                    GeometryUnit.MoveSecondPointCloserToFirstPoint(
                        newLinePoint1, 
                        points[pointsAmount - 2], 20);

                var lastLinePoint1 = point;
                var lastLinePoint2 = points[0];

                for (int i = 0; i < pointsAmount - 2; i++)
                {
                    var oldLinePoint1 = points[i];
                    var oldLinePoint2 = points[i + 1];

                    if (GeometryUnit.IsLinesIntersect(
                        newLinePoint1,
                        newLinePoint2,
                        oldLinePoint1,
                        oldLinePoint2)
                        || 
                        (i > 0
                        &&
                        GeometryUnit.IsLinesIntersect(
                        lastLinePoint1,
                        lastLinePoint2,
                        oldLinePoint1,
                        oldLinePoint2)))
                    {
                        polygonLines.Fill = Brushes.Red;
                        await System.Threading.Tasks.Task.Delay(200);
                        polygonLines.Fill = Brushes.LightGray;

                        return;
                    }
                }
            }

            polygonLines.Points.Insert(polygonLines.Points.Count - 1, point);
        }

    }
}
