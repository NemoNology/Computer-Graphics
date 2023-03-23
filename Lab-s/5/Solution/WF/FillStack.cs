using System.Runtime.CompilerServices;

namespace WF
{
    internal class FillStack : IFillingAlghoritm
    {
        private Stack<Point> _points = new Stack<Point>();

        public void Fill(ref Bitmap bmp, Point startFillPoint, Color fillColor)
        {
            var voidColor = bmp.GetPixel(startFillPoint.X, startFillPoint.Y);

            _points.Push(startFillPoint);

            while (_points.Count > 0)
            {
                var p = _points.Pop();

                bmp.SetPixel(p.X, p.Y, fillColor);

                var leftPoint = new Point(p.X - 1, p.Y);
                var rightPoint = new Point(p.X + 1, p.Y);
                var upPoint = new Point(p.X, p.Y - 1);
                var downPoint = new Point(p.X, p.Y + 1);

                if (IsValidPoint(bmp, rightPoint, voidColor))
                {
                    _points.Push(rightPoint);
                }
                if (IsValidPoint(bmp, upPoint, voidColor))
                {
                    _points.Push(upPoint);
                }
                if (IsValidPoint(bmp, leftPoint, voidColor))
                {
                    _points.Push(leftPoint);
                }
                if (IsValidPoint(bmp, downPoint, voidColor))
                {
                    _points.Push(downPoint);
                }
            }
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
    }
}