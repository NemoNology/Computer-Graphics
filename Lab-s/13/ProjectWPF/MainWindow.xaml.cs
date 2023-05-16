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

        private void PolygonTriangulation()
        {
            var points = polygonLines.Points.ToList();

            if (!GeometryUnit.IsPolygonSimple(points))
            {
                return;
            }

            while (mainView.Children.Count > 1)
            {
                mainView.Children.RemoveAt(1);
            }

            var triangles = GeometryUnit.Triangulate_EarClipping(points);

            foreach (var triangle in triangles) 
            {
                mainView.Children.Add(
                    new Polygon()
                    {
                        Stroke = Brushes.DeepSkyBlue,
                        StrokeThickness = 1,
                        Points = triangle
                    }
                ); 
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
