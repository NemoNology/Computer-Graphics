using System;
using System.Windows;
using System.Windows.Input;

namespace Units
{
    public class GeometryUnit
    {
        public static double GetTriangleArea(Point a, Point b, Point c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }

        private static bool IntersectionCheck(double a, double b, double c, double d)
        {
            if (a > b)
            {
                (a, b) = (b, a);
            }

            if (c > d)
            {
                (c, d) = (d, c);
            }

            return Math.Max(a, c) <= Math.Min(b, d);
        }

        public static bool IsLinesIntersect(Point a1, Point a2, Point b1, Point b2)
        {
            return IntersectionCheck(a1.X, a2.X, b1.X, b2.X)
                && IntersectionCheck(a1.Y, a2.Y, b1.Y, b2.Y)
                && GetTriangleArea(a1, a2, b1) * GetTriangleArea(a1, a2, b2) <= 0
                && GetTriangleArea(b1, b2, a1) * GetTriangleArea(b1, b2, a2) <= 0;
        }

        public static Point GetLineCenter(Point a, Point b)
        {
            return new Point(
                (a.X + b.X) / 2,
                (a.Y + b.Y) / 2);
        }

        public static Point MoveSecondPointCloserToFirstPoint(Point p1, Point p2, int partsAmount = 10)
        {
            var firstPointInLeft = p1.X <= p2.X;
            var firstPointInUp = p1.Y <= p2.Y;

            var Dx = firstPointInLeft ? p1.X - p2.X : p2.X - p1.X;
            var Dy = firstPointInUp ? p2.Y - p1.Y : p1.Y - p2.Y;

            return new Point(
                firstPointInLeft ? p2.X - Dx / partsAmount : p2.X + Dx / partsAmount,
                firstPointInUp ? p2.Y - Dy / partsAmount : p2.Y + Dy / partsAmount);
        }
    }
}
