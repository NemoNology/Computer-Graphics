using System.Collections.Generic;
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

        private void MainView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(mainView);
            var pointsAmount = polygonLines.Points.Count;

            // Field clearing
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                while (mainView.Children.Count > 1)
                {
                    mainView.Children.RemoveAt(1);
                }

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
                while (mainView.Children.Count > 1)
                {
                    mainView.Children.RemoveAt(1);
                }

                PolygonTriangulation();
            }
            
        }

        private bool IsPolygonSimple()
        {
            var pointsAmount = polygonLines.Points.Count;

            if (pointsAmount == 0)
            {
                MessageBox.Show("Polygon is not drawn");
                return false;
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
                        return false;
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
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private void PolygonTriangulation()
        {
            if (!IsPolygonSimple())
            {
                return;
            }

            int index = 0;

            var points = polygonLines.Points.ToList();

            var pointsAmount = points.Count;

            PointCollection triangle = new PointCollection(3);

            while (pointsAmount > 2)
            {
                var p1 = points[index % pointsAmount];
                var p2 = points[(index + 1) % pointsAmount];
                var p3 = points[(index + 2) % pointsAmount];

                triangle.Add(p1);
                triangle.Add(p2);
                triangle.Add(p3);

                

                triangle.Clear();
            }
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
