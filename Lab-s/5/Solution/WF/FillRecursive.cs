using System.Runtime.CompilerServices;

namespace WF
{
    internal class FillRecursive : IFillingAlghoritm
    {
        public void Fill(ref Bitmap bmp, Point point, Color fillColor)
        {
            var voidColor = bmp.GetPixel(point.X, point.Y);

            if (!RuntimeHelpers.TryEnsureSufficientExecutionStack() ||
            bmp.GetPixel(point.X, point.Y) != voidColor)
            {
                return;
            }

            bmp.SetPixel(point.X, point.Y, fillColor);

            var upPoint = new Point(point.X, point.Y - 1);
            var downPoint = new Point(point.X, point.Y + 1);
            var leftPoint = new Point(point.X - 1, point.Y);
            var rightPoint = new Point(point.X + 1, point.Y);

            if (upPoint.Y >= 0 &&
            bmp.GetPixel(upPoint.X, upPoint.Y) == voidColor)
            {
                Fill(ref bmp, upPoint, fillColor);
            }
            if (downPoint.Y < bmp.Height &&
            bmp.GetPixel(downPoint.X, downPoint.Y) == voidColor)
            {
                Fill(ref bmp, downPoint, fillColor);
            }
            if (leftPoint.X >= 0 &&
            bmp.GetPixel(leftPoint.X, leftPoint.Y) == voidColor)
            {
                Fill(ref bmp, leftPoint, fillColor);
            }
            if (rightPoint.X < bmp.Width &&
            bmp.GetPixel(rightPoint.X, rightPoint.Y) == voidColor)
            {
                Fill(ref bmp, rightPoint, fillColor);
            }
        }
    }
}
