using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
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

            // Points clearing
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                polygonLines.Points.Clear();
                return;
            }
            // Polygon drawing
            else if (e.LeftButton == MouseButtonState.Pressed)
            {
                PolygonPointsAdding(pointsAmount, point);
            }
            // Polygon triangulation
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                PolygonTriangulation();
            }
            
        }

        private void PolygonTriangulation()
        {
            var pointsAmount = polygonLines.Points.Count;

            if (pointsAmount == 0)
            {
                MessageBox.Show("Polygon is not drawn");
                return;
            }

            // Checking if this polygon is simple
            if (pointsAmount > 3)
            {
                var points = polygonLines.Points;

                var lastLinePoint1 = points.Last();
                var lastLinePoint2 = points[0];

                // Checking last line intersection
                for (int i = 1; i < pointsAmount - 2; i++)
                {
                    var oldLinePoint1 = points[i];
                    var oldLinePoint2 = points[i + 1];

                    if (GeometryUnit.IsLinesIntersect(
                        lastLinePoint1,
                        lastLinePoint2,
                        oldLinePoint1,
                        oldLinePoint2))
                    {
                        MessageBox.Show("Polygon is not simple");
                        return;
                    }
                }

                for (int i = 0; i < pointsAmount - 2; i++)
                {
                    var currentLinePoint1 = points[i];
                    var currentLinePoint2 = 
                        GeometryUnit.MoveSecondPointCloserToFirstPoint(
                            currentLinePoint1,
                            points[i + 1]);

                    for (int j = i + 1; j < pointsAmount - 2; j++)
                    {
                        var lineBufferPoint1 = points[j];
                        var lineBufferPoint2 = points[j + 1];

                        if (GeometryUnit.IsLinesIntersect(
                        currentLinePoint1,
                        currentLinePoint2,
                        lineBufferPoint1,
                        lineBufferPoint2))
                        {
                            MessageBox.Show("Polygon is not simple");
                            return;
                        }
                    }
                }
            }

            // TODO: Triangulation
            MessageBox.Show("Polygon is simple");
        }

        private void PolygonPointsAdding(int pointsAmount, Point point)
        {
            if (pointsAmount == 0)
            {
                polygonLines.Points.Add(point);
                polygonLines.Points.Add(point);

                return;
            }

            polygonLines.Points.Insert(pointsAmount - 1, point);
        }
    }
}
