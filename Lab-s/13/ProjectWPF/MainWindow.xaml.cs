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

        /// <summary>
        /// Not Mine <br/>
        /// link -> https://stackoverflow.com/questions/4243042/c-sharp-point-in-polygon
        /// </summary>
        /// <returns> <c> True </c> - if point is inside polygon <br/>
        /// <c> False </c> - otherwise </returns>
        private bool IsPointInsidePolygon(Point point, PointCollection polygon)
        {
            bool result = false;
            var a = polygon.Last();

            foreach (var b in polygon)
            {
                if ((b.X == point.X) && (b.Y == point.Y))
                    return true;

                if ((b.Y == a.Y) && (point.Y == a.Y))
                {
                    if ((a.X <= point.X) && (point.X <= b.X))
                        return true;

                    if ((b.X <= point.X) && (point.X <= a.X))
                        return true;
                }

                if ((b.Y < point.Y) && (a.Y >= point.Y) || (a.Y < point.Y) && (b.Y >= point.Y))
                {
                    if (b.X + (point.Y - b.Y) / (a.Y - b.Y) * (a.X - b.X) <= point.X)
                        result = !result;
                }
                a = b;
            }

            return result;
        }


        /// <summary>
        /// Not Mine <br/>
        /// link -> https://gist.github.com/KvanTTT/3855122
        /// </summary>
        private bool LineIntersect(Point A1, Point A2, Point B1, Point B2, ref Point O)
        {
            double a1 = A2.Y - A1.Y;
            double b1 = A1.X - A2.X;
            double d1 = -a1 * A1.X - b1 * A1.Y;
            double a2 = B2.Y - B1.Y;
            double b2 = B1.X - B2.X;
            double d2 = -a2 * B1.X - b2 * B1.Y;
            double t = a2 * b1 - a1 * b2;

            if (t == 0)
                return false;

            O.Y = (a1 * d2 - a2 * d1) / t;
            O.X = (b2 * d1 - b1 * d2) / t;

            if (A1.X > A2.X)
            {
                if ((O.X < A2.X) || (O.X > A1.X))
                    return true;
            }
            else
            {
                if ((O.X < A1.X) || (O.X > A2.X))
                    return true;
            }

            if (A1.Y > A2.Y)
            {
                if ((O.Y < A2.Y) || (O.Y > A1.Y))
                    return true;
            }
            else
            {
                if ((O.Y < A1.Y) || (O.Y > A2.Y))
                    return true;
            }

            if (B1.X > B2.X)
            {
                if ((O.X < B2.X) || (O.X > B1.X))
                    return true;
            }
            else
            {
                if ((O.X < B1.X) || (O.X > B2.X))
                    return true;
            }

            if (B1.Y > B2.Y)
            {
                if ((O.Y < B2.Y) || (O.Y > B1.Y))
                    return true;
            }
            else
            {
                if ((O.Y < B1.Y) || (O.Y > B2.Y))
                    return true;
            }

            return false;
        }

    }
}
