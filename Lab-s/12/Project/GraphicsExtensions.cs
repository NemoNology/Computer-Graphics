using System.Numerics;

namespace GraphicUnit
{
    public static class GraphicsExtensions
    {
        public enum Axes
        {
            X,
            Y,
            Z
        }

        /// <summary>
        /// Transform 3d point to 4d point for future manipulations
        /// </summary>
        public static Vector4 Vector3ToVector4(Vector3 v)
        {
            return new Vector4(v, 1);
        }

        /// <param name="r"> Coefficient: 1 / k - Focus distance? </param>
        /// <param name="axis"> 0 - Z Axis <br/> 1 - Y Axis <br/> 2 - X Axis </param>
        /// <returns> Matrix for transformation by inputted axis </returns>
        public static Matrix4x4 GetPerspectiveMatrix(float r, Axes axis = Axes.Z)
        {
            switch (axis)
            {
                case Axes.Z:

                    return new Matrix4x4(
                        1, 0, 0, 0,
                        0, 1, 0, 0,
                        0, 0, 0, r,
                        0, 0, 0, 1
                        );

                case Axes.Y:

                    return new Matrix4x4(
                       1, 0, 0, 0,
                       0, 0, 0, r,
                       0, 0, 1, 0,
                       0, 0, 0, 1
                       );

                case Axes.X:

                    return new Matrix4x4(
                        0, 0, 0, r,
                        0, 1, 0, 0,
                        0, 0, 1, 0,
                        0, 0, 0, 1
                        );

                default:

                    return new Matrix4x4();
            }
        }

        /// <param name="Dx"> Value by which the 3D object is translated along the X axis </param>
        /// <param name="Dy"> Value by which the 3D object is translated along the Y axis </param>
        /// <param name="Dz"> Value by which the 3D object is translated along the Z axis </param>
        /// <returns> Translate matrix by inputted values </returns>
        public static Matrix4x4 GetTranslateMatrix(float Dx, float Dy, float Dz)
        {
            return new Matrix4x4
            (
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                Dx, Dy, Dz, 0
            );
        }

        /// <param name="angleDegree"> The angle by which the 3D object will rotate </param>
        /// <param name="axis"> The axis on which 3D object will be rotated </param>
        /// <returns> Matrix for rotation 3D object around by center of coordinates </returns>
        public static Matrix4x4 GetRotationMatrix(float angleDegree, Axes axis)
        {
            var degreesToRadians = Math.PI / 180;

            var sin = (float)Math.Sin(degreesToRadians * angleDegree);
            var cos = (float)Math.Cos(degreesToRadians * angleDegree);

            switch (axis)
            {
                case Axes.X:
                    return new Matrix4x4
                        (
                        1, 0_00, 0_00, 0,
                        0, +cos, +sin, 0,
                        0, -sin, +cos, 0,
                        0, 0_00, 0_00, 1
                        );

                case Axes.Y:
                    return new Matrix4x4
                        (
                        +cos, +sin, 0, 0,
                        -sin, +cos, 0, 0,
                        0_00, 0_00, 1, 0,
                        0_00, 0_00, 0, 1
                        );

                case Axes.Z:
                    return new Matrix4x4
                        (
                        +cos, 0, -sin, 0,
                        0_00, 1, 0_00, 0,
                        +sin, 0, +cos, 0,
                        0_00, 0, 0_00, 1
                        );

                default:
                    return new Matrix4x4();
            }
        }

        /// <summary>
        /// Transform 4d point to usual 3d point after manipulations
        /// </summary>
        public static Vector3 Vector4ToVector3(Vector4 v)
        {
            return new Vector3(
                v.X / v.W,
                v.Y / v.W,
                v.Z / v.W);
        }

        /// <summary>
        /// Transform Vector3 to center projection
        /// </summary>
        /// <param name="v"> Vector that will be transformed </param>
        /// <param name="r"> Focus distance? </param>
        /// <param name="axis"> Axis by that will be transformed vector </param>
        /// <returns> Transformed vector </returns>
        public static Vector3 TransformVector(Vector3 v, float r = 100, Axes axis = Axes.Z)
        {
            return Vector4ToVector3(Vector4.Transform
                (Vector3ToVector4(v),
                GetPerspectiveMatrix(r, axis)
                ));
        }

        /// <summary>
        /// Transform Point3D to center projection
        /// </summary>
        /// <param name="p"> Point that will be transformed </param>
        /// <param name="r"> Focus distance? </param>
        /// <param name="axis"> Axis by that will be transformed vector </param>
        /// <returns> Transformed Point3D </returns>
        public static Point3D TransformPoint3D(Point3D p, float r = 100, Axes axis = Axes.Z)
        {
            return new Point3D(TransformVector(p.Vector3, r, axis));
        }

        ///// <param name="p"> Point3D from which coordinates X & Y will be taken </param>
        ///// <returns> X and Y coordinates by inputted Point3D </returns>
        //public static (float x, float y) Point3DToXY(Point3D p)
        //{
        //    return (p.X, p.Y);
        //}

        //public static List<((float x, float y) pair1, (float x, float y) pair2)> Points3DPairsToXYPairs(List<(Point3D point1, Point3D point2)> pointsPairs)
        //{
        //    var res = new List<((float x, float y) pair1, (float x, float y) pair2)>(pointsPairs.Count);

        //    foreach (var pointsPair in pointsPairs)
        //    {
        //        res.Add((Point3DToXY(pointsPair.point1), Point3DToXY(pointsPair.point2)));
        //    }

        //    return res;
        //}



    }

    public interface IObject3D
    {
        /// <summary>
        /// Transform 3D object by transform matrix
        /// </summary>
        /// <param name="transformMatrix"> Matrix with which 3D object will be transformed </param>
        public void Transform(Matrix4x4 transformMatrix);
    }

    public class Point3D : IObject3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        /// <summary>
        /// New Vector3 by XYZ values
        /// </summary>
        public Vector3 Vector3 => new Vector3(X, Y, Z);

        public void Transform(Matrix4x4 transformMatrix)
        {
            var transformedVector =
                Vector4.Transform(
                    new Vector4(X, Y, Z, 1),
                    transformMatrix);



            X = transformedVector.X;
            Y = transformedVector.Y;
            Z = transformedVector.Z;
        }

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(Vector3 v)
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public Point3D()
        {
            X = Y = Z = 0;
        }

        public Point3D Clone => new Point3D(X, Y, Z);

        public static Point3D operator +(Point3D point1, Point3D point2)
        {
            return new Point3D(
                point1.X + point2.X,
                point1.Y + point2.Y,
                point1.Z + point2.Z);
        }

        public static Point3D operator -(Point3D point1, Point3D point2)
        {
            return new Point3D(
                point1.X - point2.X,
                point1.Y - point2.Y,
                point1.Z - point2.Z);
        }

        public static Point3D operator -(Point3D point)
        {
            return new Point3D(
                -point.X,
                -point.Y,
                -point.Z
                );
        }

        /// <summary>
        /// New PointF by X and Y values
        /// </summary>
        public PointF PointF => new PointF(X, Y);
    }

    public class Square3D : IObject3D
    {
        public List<Point3D> Points { get; private set; }

        public Point3D A => Points[0];
        public Point3D B => Points[1];
        public Point3D C => Points[2];
        public Point3D D => Points[3];

        public Square3D()
        {
            Points = new List<Point3D>(4)
            {
                new Point3D(-0.5f, 0, 0.5f),
                new Point3D(0.5f, 0, 0.5f),
                new Point3D(0.5f, 0, -0.5f),
                new Point3D(-0.5f, 0, -0.5f)
            };
        }

        public Square3D(Point3D squareLeftUpPoint, float sideLength)
        {
            var x = squareLeftUpPoint.X;
            var y = squareLeftUpPoint.Y;
            var z = squareLeftUpPoint.Z;

            Points = new List<Point3D>(4)
            {
                new Point3D(x, y, z),
                new Point3D(x + sideLength, y, z),
                new Point3D(x + sideLength, y, z - sideLength),
                new Point3D(x, y, z - sideLength)
            };
        }

        /// <summary>
        /// Square edges as list of pairs of points
        /// </summary>
        public List<(Point3D point1, Point3D point2)> Edges
        {
            get
            {
                return new List<(Point3D point1, Point3D point2)> {
                    (A, B),
                    (B, C),
                    (C, D),
                    (D, A)
                };
            }
        }

        public void Transform(Matrix4x4 transformMatrix)
        {
            Parallel.ForEach(Points, point =>
            {
                point.Transform(transformMatrix);
            });
        }

        /// <summary>
        /// Center point of square
        /// </summary>
        public Point3D CenterPoint
        {
            get
            {
                var a = A.Clone;
                var c = C.Clone;

                return new Point3D(
                    (a.X + c.X) / 2,
                    (a.Y + c.Y) / 2,
                    (a.Z + c.Z) / 2
                    );
            }
        }



    }

    public class Cube : IObject3D
    {
        public List<Point3D> Points { get; private set; } = new List<Point3D>(8);

        public Point3D A => Points[0];
        public Point3D B => Points[1];
        public Point3D C => Points[2];
        public Point3D D => Points[3];
        public Point3D A1 => Points[4];
        public Point3D B1 => Points[5];
        public Point3D C1 => Points[6];
        public Point3D D1 => Points[7];

        /// <summary>
        /// Initialize new cube in coordinates center with zero length
        /// </summary>
        public Cube()
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points.Add(new Point3D());
            }
        }

        /// <summary>
        /// Initialize new cube by cube center coordinates with inputted side length
        /// </summary>
        /// <param name="cubeCenter"> Center of cube </param>
        /// <param name="cubeSideLength"> Side length of cube </param>
        public Cube(Point3D cubeCenter, float cubeSideLength)
        {
            var halsSideLength = cubeSideLength / 2;

            var x = cubeCenter.X;
            var y = cubeCenter.Y;
            var z = cubeCenter.Z;

            Points = new List<Point3D>(8)
            {
                new Point3D(x - halsSideLength, y + halsSideLength, z + halsSideLength),
                new Point3D(x + halsSideLength, y + halsSideLength, z + halsSideLength),
                new Point3D(x + halsSideLength, y + halsSideLength, z - halsSideLength),
                new Point3D(x - halsSideLength, y + halsSideLength, z - halsSideLength),

                new Point3D(x - halsSideLength, y - halsSideLength, z + halsSideLength),
                new Point3D(x + halsSideLength, y - halsSideLength, z + halsSideLength),
                new Point3D(x + halsSideLength, y - halsSideLength, z - halsSideLength),
                new Point3D(x - halsSideLength, y - halsSideLength, z - halsSideLength)
            };
        }

        public List<(Point3D point1, Point3D point2)> Edges
        {
            get
            {
                return new List<(Point3D point1, Point3D point2)>(12)
                {
                    (A, B),
                    (B, C),
                    (C, D),
                    (D, A),

                    (A, A1),
                    (B, B1),
                    (C, C1),
                    (D, D1),

                    (A1, B1),
                    (B1, C1),
                    (C1, D1),
                    (D1, A1)
                };
            }
        }

        public void Transform(Matrix4x4 transformMatrix)
        {
            Parallel.ForEach(Points, point =>
            {
                point.Transform(transformMatrix);
            });
        }
    }
}