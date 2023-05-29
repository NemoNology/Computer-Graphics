using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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

        public static Point MoveSecondPointCloserToFirstPoint(
            Point p1,
            Point p2,
            int partsAmount = 20
        )
        {
            var firstPointInLeft = p1.X <= p2.X;
            var firstPointInUp = p1.Y <= p2.Y;

            var Dx = firstPointInLeft ? p2.X - p1.X : p1.X - p2.X;
            var Dy = firstPointInUp ? p2.Y - p1.Y : p1.Y - p2.Y;

            return new Point(
                firstPointInLeft ? p2.X - Dx / partsAmount : p2.X + Dx / partsAmount,
                firstPointInUp ? p2.Y - Dy / partsAmount : p2.Y + Dy / partsAmount
            );
        }

        public static List<PointCollection> Triangulate_EarClipping(List<Point> polygonPoints)
        {
            var diagonals = new List<PointCollection>();

            if (!IsPolygonDirectionIsClockwise(polygonPoints))
            {
                polygonPoints.Reverse();
            }

            while (polygonPoints.Count > 3)
            {
                for (int i = 0; i < polygonPoints.Count; i++)
                {
                    var p1 = polygonPoints[i];
                    var p2 = polygonPoints[(i + 1) % polygonPoints.Count];
                    var p3 = polygonPoints[(i + 2) % polygonPoints.Count];

                    if (!IsPolygonDirectionIsClockwise(new List<Point>() { p1, p2, p3 }))
                    {
                        continue;
                    }

                    var isEar = true;

                    foreach (var point in polygonPoints)
                    {
                        if (point == p1 || point == p2 || point == p3)
                        {
                            continue;
                        }

                        if (IsPointInsideTriangle(point, p1, p2, p3))
                        {
                            isEar = false;
                            break;
                        }
                    }

                    if (isEar)
                    {
                        diagonals.Add(new PointCollection { p1, p3 });
                        polygonPoints.Remove(p2);
                    }
                }
            }

            return diagonals;
        }

        public static bool IsPointInsideTriangle(Point point, Point p1, Point p2, Point p3)
        {
            return IsPolygonDirectionIsClockwise(new List<Point>() { point, p1, p2 })
                && IsPolygonDirectionIsClockwise(new List<Point>() { point, p2, p3 })
                && IsPolygonDirectionIsClockwise(new List<Point>() { point, p3, p1 });
        }

        public static bool IsPolygonSimple(List<Point> polygonPoints)
        {
            var pointsAmount = polygonPoints.Count;

            if (pointsAmount == 0)
            {
                MessageBox.Show("Polygon is not drawn");
                return false;
            }

            // Checking if this polygon is simple
            if (pointsAmount > 3)
            {
                var points = polygonPoints;

                var lastLinePoint1 = points.Last();
                var lastLinePoint2 = points[0];

                // Checking last line intersection
                for (int i = 1; i < pointsAmount - 2; i++)
                {
                    var oldLinePoint1 = points[i];
                    var oldLinePoint2 = points[i + 1];

                    if (
                        GeometryUnit.IsLinesIntersect(
                            lastLinePoint1,
                            lastLinePoint2,
                            oldLinePoint1,
                            oldLinePoint2
                        )
                    )
                    {
                        MessageBox.Show("Polygon is not simple");
                        return false;
                    }
                }

                for (int i = 0; i < pointsAmount - 2; i++)
                {
                    var currentLinePoint1 = points[i];
                    var currentLinePoint2 = GeometryUnit.MoveSecondPointCloserToFirstPoint(
                        currentLinePoint1,
                        points[i + 1]
                    );

                    for (int j = i + 1; j < pointsAmount - 2; j++)
                    {
                        var lineBufferPoint1 = points[j];
                        var lineBufferPoint2 = points[j + 1];

                        if (
                            GeometryUnit.IsLinesIntersect(
                                currentLinePoint1,
                                currentLinePoint2,
                                lineBufferPoint1,
                                lineBufferPoint2
                            )
                        )
                        {
                            MessageBox.Show("Polygon is not simple");
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static bool IsPolygonDirectionIsClockwise(List<Point> polygonPoints)
        {
            double s = 0;

            var pointsAmount = polygonPoints.Count;

            for (int i = 0; i < pointsAmount; i++)
            {
                var p1 = polygonPoints[i];
                var p2 = polygonPoints[(i + 1) % pointsAmount];

                s += (p2.X - p1.X) * (p2.Y + p1.Y);
            }

            return s > 0;
        }

        public static bool IsTriangleIsEar(
            Point a,
            Point b,
            Point c,
            bool isPolygonDirectionIsClockwise = true
        )
        {
            var isTriangleDirectionIsClockwise = IsPolygonDirectionIsClockwise(
                new List<Point> { a, b, c }
            );

            return isPolygonDirectionIsClockwise == isTriangleDirectionIsClockwise;
        }
    }
}
