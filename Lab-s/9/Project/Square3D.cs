using System.Numerics;

namespace Project
{
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

        /// <summary>
        /// List of square edges as pairs of neighbor points
        /// </summary>
        /// <param name="r"> Focus distance? Something... </param>
        /// <param name="axis"> Projection Axis <br/> Axis Z - 0 <br/> Axis Y - 1 <br/> Axis X - 2 </param>
        /// <returns></returns>
        public List<(
            (float X, float Y) point1,
            (float X, float Y) point2
            )> GetEdgesInCentralProjection(float r = 0.01f, int axis = 0)
        {
            return new List<(
                (float X, float Y) point1,
                (float X, float Y) point2)>
            {
                (A.GetCentralProjection(r, axis), B.GetCentralProjection(r, axis)),
                (B.GetCentralProjection(r, axis), C.GetCentralProjection(r, axis)),
                (C.GetCentralProjection(r, axis), D.GetCentralProjection(r, axis)),
                (D.GetCentralProjection(r, axis), A.GetCentralProjection(r, axis))
            };
        }

        public void Translate(float Dx = 0, float Dy = 0, float Dz = 0)
        {
            Parallel.ForEach(Points, point =>
            {
                point.Translate(Dx, Dy, Dz);
            });
        }

        /// <summary>
        /// Rotate square around a center point by inputted angle on inputted Axis
        /// </summary>
        /// <param name="centerPoint"> The point around which the rotation will be reproduced </param>
        /// <param name="rotationAngleDegree"> Rotation angle in degrees </param>
        /// <param name="rotationAxis"> The axis along which the rotation will be reproduced <br/>
        /// Axis X - 0 <br/> Axis Y - 1 <br/> Axis Z - 2 </param>
        public void RotateAt(Point3D centerPoint,
            float rotationAngleDegree, int rotationAxis = 0)
        {
            Parallel.ForEach(Points, point =>
            {
                point.RotateAt(centerPoint, rotationAngleDegree, rotationAxis);
            });
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
                var a = A;
                var c = C;

                return new Point3D(
                    (a.X + c.X) / 2,
                    (a.Y + c.Y) / 2,
                    (a.Z + c.Z) / 2
                    );
            }
        }

        /// <summary>
        /// Array of square points as PointF
        /// </summary>
        /// <param name="r"> Focus distance? Something... </param>
        /// <param name="axis"> Projection Axis <br/> Axis Z - 0 <br/> Axis Y - 1 <br/> Axis X - 2 </param>
        public PointF[] GetPolygonPointsInCentralProjection(float r = 0.01f, int axis = 0)
        {
            var pointsAmount = Points.Count;

            PointF[] res = new PointF[pointsAmount];

            for (int i = 0; i < pointsAmount; i++)
            {
                var p = Points[i].GetCentralProjection(r, axis);

                res[i] = new PointF(p.X, p.Y);
            }

            return res;
        }

    }
}
