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

                if (rightPoint.X < bmp.Width &&
                bmp.GetPixel(rightPoint.X, rightPoint.Y) == voidColor)
                {
                    _points.Push(rightPoint);
                }
                if (upPoint.Y >= 0 &&
                bmp.GetPixel(upPoint.X, upPoint.Y) == voidColor)
                {
                    _points.Push(upPoint);
                }
                if (leftPoint.X >= 0 &&
                bmp.GetPixel(leftPoint.X, leftPoint.Y) == voidColor)
                {
                    _points.Push(leftPoint);
                }
                if (downPoint.Y < bmp.Height &&
                bmp.GetPixel(downPoint.X, downPoint.Y) == voidColor)
                {
                    _points.Push(downPoint);
                }
            }
        }
    }
}