using System.Runtime.CompilerServices;

namespace WF
{
    internal class FillQueue : IFillingAlghoritm
    {
        private Queue<Point> _points = new Queue<Point>();

        public void Fill(ref Bitmap bmp, Point startFillPoint, Color fillColor)
        {
            var voidColor = bmp.GetPixel(startFillPoint.X, startFillPoint.Y);

            _points.Enqueue(startFillPoint);

            while (_points.Count > 0)
            {
                var p = _points.Dequeue();

                bmp.SetPixel(p.X, p.Y, fillColor);

                var leftPoint = new Point(p.X - 1, p.Y);
                var rightPoint = new Point(p.X + 1, p.Y);
                var upPoint = new Point(p.X, p.Y - 1);
                var downPoint = new Point(p.X, p.Y + 1);

                if (rightPoint.X < bmp.Width &&
                bmp.GetPixel(rightPoint.X, rightPoint.Y) == voidColor)
                {
                    _points.Enqueue(rightPoint);
                }
                if (upPoint.Y >= 0 &&
                bmp.GetPixel(upPoint.X, upPoint.Y) == voidColor)
                {
                    _points.Enqueue(upPoint);
                }
                if (leftPoint.X >= 0 &&
                bmp.GetPixel(leftPoint.X, leftPoint.Y) == voidColor)
                {
                    _points.Enqueue(leftPoint);
                }
                if (downPoint.Y < bmp.Height &&
                bmp.GetPixel(downPoint.X, downPoint.Y) == voidColor)
                {
                    _points.Enqueue(downPoint);
                }
            }
        }
    }
}