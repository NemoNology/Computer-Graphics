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

        public static double GetTriangleArea_2(Point a, Point b, Point c)
        {
            var x1 = a.X;
            var x2 = b.X;
            var x3 = c.X;
            var y1 = a.Y;
            var y2 = b.Y;
            var y3 = c.Y;

            return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2);
        }

        public static double GetTriangleSum(Point a, Point b, Point c)
        {
            var x1 = a.X;
            var x2 = b.X;
            var x3 = c.X;
            var y1 = a.Y;
            var y2 = b.Y;
            var y3 = c.Y;

            return x1 * (y3 - y2) + x2 * (y1 - y3) + x3 * (y2 - y1);
        }

        public static bool IsPointInsideTriangle(Point p, Point a, Point b, Point c)
        {
            var area = GetTriangleArea_2(a, b, c);
            var area1 = GetTriangleArea_2(p, b, c);
            var area2 = GetTriangleArea_2(p, a, c);
            var area3 = GetTriangleArea_2(p, a, b);
            return Math.Abs(area - area1 + area2 + area3) <= 0.001;
        }

        public static bool IsPointsNotInsideTriangle(
            Point a,
            Point b,
            Point c,
            List<Point> polygonPoints
        )
        {
            foreach (var point in polygonPoints)
            {
                if (point.Equals(a) || point.Equals(b) || point.Equals(c))
                {
                    continue;
                }
                else if (IsPointInsideTriangle(point, a, b, c))
                {
                    return false;
                }
            }

            return true;
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
            return new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
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

        private static double Determinant(Point u, Point v)
        {
            return u.X * v.Y - u.Y * v.X;
        }

        private static bool collisionTrianglePoint(Point a, Point b, Point c, Point point)
        {
            Point ab = new Point(b.X - a.X, b.Y - a.Y);
            Point bc = new Point(c.X - b.X, c.Y - b.Y);
            Point ca = new Point(a.X - c.X, a.Y - c.Y);

            if (
                Determinant(ab, new Point(point.X - a.X, point.Y - a.Y)) > 0
                && Determinant(bc, new Point(point.X - b.X, point.Y - b.Y)) > 0
                && Determinant(ca, new Point(point.X - c.X, point.Y - c.Y)) > 0
            )
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// NOT WORKING
        /// </summary>
        public static List<PointCollection> Triangulate_EarClipping(List<Point> polygonPoints)
        {
            var points = polygonPoints.ToList();

            var triangles = new List<PointCollection>();

            while (points.Count > 3)
            {
                var i = 0;

                while (!IsTriangleIsEar(points[0], points[i + 1], points[i + 2], points))
                {
                    i++;
                }

                triangles.Add(new PointCollection { points[0], points[i + 2] });

                points.RemoveAt(i + 2);
            }

            return triangles;
        }

        public static List<PointCollection> Triangulate_Custom(List<Point> polygonPoints)
        {
            var points = polygonPoints.ToList();

            var triangles = new List<PointCollection>();

            var pointsAmount = points.Count;

            for (int i = 0; i < pointsAmount; i++)
            {
                var point = points[i];

                for (int j = 0; j < pointsAmount; j++)
                {
                    var pointBuffer = points[j];

                    if (IsAllLinePointsInsidePolygon
                    (
                        LineSeparation(point, pointBuffer, 20),
                        points
                    ))
                    {
                        triangles.Add(new PointCollection { point, pointBuffer });
                    }
                }
            }

            return triangles;
        }

        public static bool IsPointInsidePolygon(Point point, List<Point> polygonPoints)
        {
            bool result = false;

            foreach (var polygonPoint in polygonPoints)
            {
                if (point == polygonPoint)
                {
                    return false;
                }
            }

            var size = polygonPoints.Count;

            int j = size - 1;

            for (int i = 0; i < size; i++)
            {
                if (
                    (
                        polygonPoints[i].Y < point.Y && polygonPoints[j].Y >= point.Y
                        || polygonPoints[j].Y < point.Y && polygonPoints[i].Y >= point.Y
                    )
                    && (
                        polygonPoints[i].X
                            + (point.Y - polygonPoints[i].Y)
                                / (polygonPoints[j].Y - polygonPoints[i].Y)
                                * (polygonPoints[j].X - polygonPoints[i].X)
                        < point.X
                    )
                )
                    result = !result;
                j = i;
            }

            return result;
        }

        public static List<Point> LineSeparation(Point a, Point b, int divisionsAmount)
        {
            var Dx = Math.Abs(a.X - b.X) / divisionsAmount;
            var Dy = Math.Abs(a.Y - b.Y) / divisionsAmount;

            var res = new List<Point>(divisionsAmount);

            if (a.X > b.X)
            {
                (a.X, b.X) = (b.X, a.X);
            }

            if (a.Y > b.Y)
            {
                (a.Y, b.Y) = (b.Y, a.Y);
            }

            for (int i = 0; i < divisionsAmount; i++)
            {
                res.Add(new Point(a.X + Dx * i, a.Y + Dy * i));
            }

            return res;
        }

        public static bool IsAllLinePointsInsidePolygon(
            List<Point> linePoints,
            List<Point> polygonPoints
        )
        {
            for (int i = 1; i < linePoints.Count - 1; i++)
            {
                if (!IsPointInsidePolygon(linePoints[i], polygonPoints))
                {
                    return false;
                }
            }

            return true;
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

        public static bool IsTriangleConvex(Point a, Point b, Point c)
        {
            return GetTriangleSum(a, b, c) < 0;
        }

        public static bool IsTriangleIsEar(Point a, Point b, Point c, List<Point> polygonPoints)
        {
            var isPolygonDirectionIsClockwise = IsPolygonDirectionIsClockwise(polygonPoints);

            var isTriangleDirectionIsClockwise = IsPolygonDirectionIsClockwise(
                new List<Point> { a, b, c }
            );

            if (isPolygonDirectionIsClockwise != isTriangleDirectionIsClockwise)
            {
                return false;
            }

            var vertexIndex = polygonPoints.IndexOf(b);

            return true;
        }

        private static bool IsTriangleIsEar_2(Point a, Point b, Point c, List<Point> polygonPoints)
        {
            return IsPointsNotInsideTriangle(a, b, c, polygonPoints)
                && IsTriangleConvex(a, b, c)
                && GetTriangleArea_2(a, b, c) > 0;
        }
    }
}
