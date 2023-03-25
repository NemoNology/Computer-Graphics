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

            // If Line lenght is 1 pixel, then...
            if (bmp.GetPixel(lp.X + 1, lp.Y) != voidColor || lp.X + 1 >= bmp.Width)
            {
                // Fill Firts Pixel
                bmp.SetPixel(lp.X, lp.Y, fillColor);

                // Save Up Point
                if (lp.Y - 1 >= 0 && bmp.GetPixel(lp.X, lp.Y - 1) == voidColor)
                {
                    Branches.Push(lp.PointWithMove(0, -1));
                }

                // Save Down Point
                if (lp.Y + 1 < bmp.Height && bmp.GetPixel(lp.X, lp.Y + 1) == voidColor)
                {
                    Branches.Push(lp.PointWithMove(0, 1));
                }

                return;
            }

            var rp = lp.Copy;

            bool IsOnTheSameHeightUp = false;
            bool IsOnTheSameHeightDown = false;

            // Going to Right and save Up or/and Down point, if it's possible
            while (rp.X < bmp.Width && bmp.GetPixel(rp.X, rp.Y) == voidColor)
            {
                bmp.SetPixel(rp.X, rp.Y, fillColor);

                var checkUp = rp.Y - 1 >= 0 && bmp.GetPixel(rp.X, rp.Y - 1) == voidColor;

                if (!IsOnTheSameHeightUp && checkUp)
                {
                    Branches.Push(rp.PointWithMove(0, -1));
                    IsOnTheSameHeightUp = true;
                }
                else if (!checkUp)
                {
                    IsOnTheSameHeightUp = false;
                }

                var checkDown = rp.Y + 1 < bmp.Height && bmp.GetPixel(rp.X, rp.Y + 1) == voidColor;

                if (!IsOnTheSameHeightDown && checkDown)
                {
                    Branches.Push(rp.PointWithMove(0, 1));
                    IsOnTheSameHeightDown = true;
                }
                else if (!checkDown)
                {
                    IsOnTheSameHeightDown = false;
                }

                rp.X++;
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

        public MyPoint Copy => new MyPoint(X, Y);
    }
}
