using System.Runtime.CompilerServices;

namespace WF
{
    internal class FillLine : IFillingAlghoritm
    {
        public void Fill(ref Bitmap bmp, Point startFillPoint, Color fillColor)
        {
            var voidColor = bmp.GetPixel(startFillPoint.X, startFillPoint.Y);

            var g = Graphics.FromImage(bmp);

            FillHorizontal(bmp, startFillPoint,
            fillColor, voidColor,
            ref g);
        }

        private bool IsValidPoint(Bitmap bmp, Point point, Color voidColor)
        {
            if (!RuntimeHelpers.TryEnsureSufficientExecutionStack())
            {
                return false;
            }

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

        private void MoveMainPoint(Bitmap bmp,
        ref MyPoint leftPoint, Color voidColor,
        bool IsRight = false, bool IsDown = false)
        {
            var Dx = IsRight ? 1 : -1;
            var Dy = IsDown ? 1 : -1;

            while (!IsValidPoint(bmp, leftPoint.PointWithMove(0, Dy), voidColor) &&
                IsValidPoint(bmp, leftPoint.PointWithMove(-Dx), voidColor))
            {
                leftPoint.X += -Dx;
            }

            if (IsValidPoint(bmp, leftPoint.PointWithMove(0, Dy), voidColor))
            {
                leftPoint.Y += Dy;
            }

            while (IsValidPoint(bmp, leftPoint.PointWithMove(Dx), voidColor))
            {
                leftPoint.X += Dx;
            }
        }

        private void MoveSecondaryPoint(Bitmap bmp,
        ref MyPoint rightPoint, Color voidColor,
        bool IsLeft = false)
        {
            var Dx = IsLeft ? -1 : 1;

            while (IsValidPoint(bmp, rightPoint.PointWithMove(Dx), voidColor))
            {
                rightPoint.X += Dx;
            }
        }

        private void FillHorizon(Bitmap bmp, Point startFillPoint,
        Color fillColor, Color voidColor,
        ref Graphics g,
        bool IsRight = false, bool IsDown = false)
        {
            var mp = new MyPoint(startFillPoint.X, startFillPoint.Y);
            var sp = mp.Copy;

            var Dx = IsRight ? 1 : -1;

            while (IsValidPoint(bmp, mp.PointWithMove(Dx), voidColor))
            {
                mp.X += Dx;
            }

            while (IsValidPoint(bmp, sp.PointWithMove(-Dx), voidColor))
            {
                sp.X += -Dx;
            }

            var bufMP = mp.Copy;
            var bufSP = sp.Copy;

            var oldMP = new MyPoint();
            var oldSP = new MyPoint();

            while (oldMP != mp && oldSP != sp)
            {
                oldMP = mp.Copy;
                oldSP = sp.Copy;

                MoveMainPoint(bmp, ref mp, voidColor, IsRight, IsDown);

                sp = mp.Copy;

                MoveSecondaryPoint(bmp, ref sp, voidColor, IsRight);

                g.DrawLine(new Pen(fillColor), bufMP.Point, bufSP.Point);

                bufMP = mp.Copy;
                bufSP = sp.Copy;
            }
        }

        private void FillHorizontal(Bitmap bmp, Point startFillPoint,
        Color fillColor, Color voidColor,
        ref Graphics g)
        {
            // Left Up
            FillHorizon(bmp, startFillPoint, 
            fillColor, voidColor,
            ref g);

            // Right Up
            FillHorizon(bmp, startFillPoint, 
            fillColor, voidColor,
            ref g, true);

            // Left Down
            FillHorizon(bmp, startFillPoint, 
            fillColor, voidColor,
            ref g, false, true);

            // Right Down
            FillHorizon(bmp, startFillPoint, 
            fillColor, voidColor,
            ref g, true, true);
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
