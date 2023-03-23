using System.Runtime.CompilerServices;

namespace WF
{
    internal class FillRecursive : IFillingAlghoritm
    {
        public void Fill(ref Bitmap bmp, Point startFillPoint, Color fillColor)
        {
            var voidColor = bmp.GetPixel(startFillPoint.X, startFillPoint.Y);

            if (IsValidPoint(bmp, startFillPoint, voidColor))
            {
                bmp.SetPixel(startFillPoint.X, startFillPoint.Y, fillColor);
            }
            else
            {
                return;
            }

            var leftPoint = new Point(startFillPoint.X - 1, startFillPoint.Y);
            var rightPoint = new Point(startFillPoint.X + 1, startFillPoint.Y);
            var upPoint = new Point(startFillPoint.X, startFillPoint.Y - 1);
            var downPoint = new Point(startFillPoint.X, startFillPoint.Y + 1);

            if (IsValidPoint(bmp, upPoint, voidColor))
            {
                Fill(ref bmp, upPoint, fillColor);
            }
            if (IsValidPoint(bmp, downPoint, voidColor))
            {
                Fill(ref bmp, downPoint, fillColor);
            }
            if (IsValidPoint(bmp, leftPoint, voidColor))
            {
                Fill(ref bmp, leftPoint, fillColor);
            }
            if (IsValidPoint(bmp, rightPoint, voidColor))
            {
                Fill(ref bmp, rightPoint, fillColor);
            }
            
        }

        private bool IsValidPoint(Bitmap bmp, Point point, Color voidColor)
        {
            if (!RuntimeHelpers.TryEnsureSufficientExecutionStack())
            {
                return false;
            }

            if ((point.X > 0 && point.X < bmp.Width) &&
                (point.Y > 0 && point.Y < bmp.Height) &&
                bmp.GetPixel(point.X, point.Y) == voidColor)
            {
                return true;
            }

            return false;
        }
    }
}
