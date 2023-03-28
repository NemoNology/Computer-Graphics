namespace Project2
{
    public class MyPoint
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public MyPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point PointWithMove(int x, int y = 0)
        {
            return new Point(X + x, Y + y);
        }

        public MyPoint Copy => new MyPoint(X, Y);
    }
}