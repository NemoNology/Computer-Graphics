namespace WF
{
    internal class FillLine : IFillingAlghoritm
    {
        private List<Point> Branches { get; set; } = new List<Point>();

        public void Fill(ref Bitmap bmp, Point startFillPoint, Color fillColor)
        {
            var voidColor = bmp.GetPixel(startFillPoint.X, startFillPoint.Y);

            Branches.Add(startFillPoint);

            while (Branches.Count > 0)
            {
                FillHorizon(bmp, Branches.First(),
                fillColor, voidColor);
            }
        }

        private bool IsValidPoint(Bitmap bmp, Point point, Color voidColor)
        {
            var x = point.X;
            var y = point.Y;

            if ((x >= 0 && x < bmp.Width) &&
                (y >= 0 && y < bmp.Height) &&
                bmp.GetPixel(x, y) == voidColor)
            {
                return true;
            }

            return false;
        }

        private void FillHorizon(Bitmap bmp, Point startFillPoint,
        Color fillColor, Color voidColor)
        {
            // Left & Right Points
            var lp = new MyPoint(startFillPoint.X, startFillPoint.Y);
            var rp = lp.Copy;

            while (IsValidPoint(bmp, lp.PointWithMove(-1), voidColor))
            {
                lp.X--;
            }

            rp = lp.Copy;

            bool upC = false;
            bool downC = false;

            while (IsValidPoint(bmp, rp.PointWithMove(1), voidColor))
            {
                rp.X++;

				var canUp = IsValidPoint(bmp, rp.PointWithMove(0, -1), voidColor);

                if (!upC && canUp)
                {
                    Branches.Add(rp.PointWithMove(0, -1));
                    upC = true;
                }
                else if (canUp)
                {
                    upC = true;
                }
                else
                {
                    upC = false;
                }

				var canDown = IsValidPoint(bmp, rp.PointWithMove(0, 1), voidColor);

                if (!downC && canDown)
                {
                    Branches.Add(rp.PointWithMove(0, 1));
                    downC = true;
                }
                else if (canDown)
                {
                    downC = true;
                }
                else
                {
                    downC = false;
                }
            }

            bmp = DrawLine(bmp, lp.X, rp.X, lp.Y, fillColor);

            Branches = Branches.FindAll(x => IsValidPoint(bmp, x, voidColor));
        }

        private Bitmap DrawLine(Bitmap bmp, int x1, int x2, int y, Color lineColor)
        {
            for (var i = x1; i <= x2; i++)
            {
                bmp.SetPixel(i, y, lineColor);
            }
            
            return bmp;
        }
    }

    public struct MyPoint
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public Point Point => new Point(X, Y);

        public MyPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point PointWithMove(int x, int y = 0)
        {
            return new Point(X + x, Y + y);
        }

        public MyPoint(MyPoint point)
        {
            X = point.X;
            Y = point.Y;
        }

        public MyPoint Copy => new MyPoint(this);


        public static bool operator ==(MyPoint p1, MyPoint p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(MyPoint p1, MyPoint p2)
        {
            return p1.X != p2.X || p1.Y != p2.Y;
        }
    }
}
