using System;
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
            var pointsAmount = polygon.Points.Count;

            // Field clearing
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                while (mainView.Children.Count > 1)
                {
                    mainView.Children.RemoveAt(1);
                }

                polygon.Points.Clear();

                return;
            }
            // Polygon drawing
            else if (e.LeftButton == MouseButtonState.Pressed)
            {
                polygon.Points.Add(point);
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
            var points = polygon.Points.ToList();

            if (!GeometryUnit.IsPolygonSimple(points))
            {
                return;
            }

            while (mainView.Children.Count > 1)
            {
                mainView.Children.RemoveAt(1);
            }

            var triangles = GeometryUnit.Triangulate_Custom(points);

            foreach (var triangle in triangles) 
            {
                mainView.Children.Add(
                    new Polygon()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 1,
                        Points = triangle
                    }
                ); 
            }
        }
    }
}
