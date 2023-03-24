namespace WF
{
    internal class FillLine : IFillingAlghoritm
    {
        private Stack<Point> Branches { get; set; } = new Stack<Point>();

        public void Fill(ref Bitmap bmp, Point startFillPoint, Color fillColor)
        {
            var voidColor = bmp.GetPixel(startFillPoint.X, startFillPoint.Y);

            Branches.Push(startFillPoint);

            while (Branches.Count > 0)
            {
                FillHorizon(bmp, Branches.Pop(),
                fillColor, voidColor, false);
            }

            Branches.Push(startFillPoint);

            while (Branches.Count > 0)
            {
                FillHorizon(bmp, Branches.Pop(),
                fillColor, voidColor, true);
            }
        }

        private void FillHorizon(Bitmap bmp, Point startFillPoint,
        Color fillColor, Color voidColor, bool IsDown)
        {
            // Left & Right Points
            var lp = new MyPoint(startFillPoint.X, startFillPoint.Y);

            // Move Left Point to Left
            while (lp.X - 1 >= 0 && bmp.GetPixel(lp.X - 1, lp.Y) == voidColor)
            {
                lp.X--;
            }

            var rp = lp.Copy;

            bool IsOnTheSameHeight = false;

            int Dy = IsDown ? 1 : -1;

            // Going to Right and save Up/Down point, if it's possible
            while (rp.X < bmp.Width && bmp.GetPixel(rp.X, rp.Y) == voidColor)
            {
                bmp.SetPixel(rp.X, rp.Y, fillColor);

                rp.X++;

                var checkVertical = rp.Y + Dy >= 0 && bmp.GetPixel(lp.X, lp.Y + Dy) == voidColor;

                if (!IsOnTheSameHeight && checkVertical)
                {
                    Branches.Push(rp.PointWithMove(0, Dy));
                    IsOnTheSameHeight = true;
                }
                else if (!checkVertical)
                {
                    IsOnTheSameHeight = false;
                    checkVertical = true;
                }
            }
        }
    }

    public struct MyPoint
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

        public MyPoint(MyPoint point)
        {
            X = point.X;
            Y = point.Y;
        }

        public MyPoint Copy => new MyPoint(this);
    }
}
