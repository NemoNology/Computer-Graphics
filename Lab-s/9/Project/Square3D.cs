using System.Numerics;

namespace Project
{
    public class Square3D : IObject3D
    {
        public List<Point3D> Points { get; } = new List<Point3D>(4);

        public Point3D A => Points[0];
        public Point3D B => Points[1];
        public Point3D C => Points[2];
        public Point3D D => Points[3];

        public Square3D()
        {
            Points.Add(new Point3D(-0.5f, 0, 0.5f));
            Points.Add(new Point3D(0.5f, 0, 0.5f));
            Points.Add(new Point3D(0.5f, 0, -0.5f));
            Points.Add(new Point3D(-0.5f, 0, -0.5f));
        }

        public Square3D(Point3D squareLeftUpPoint, float sideLength)
        {
            var x = squareLeftUpPoint.X;
            var y = squareLeftUpPoint.Y;
            var z = squareLeftUpPoint.Z;

            Points.Add(new Point3D(x, y, z));
            Points.Add(new Point3D(x + sideLength, y, z));
            Points.Add(new Point3D(x + sideLength, y, z - sideLength));
            Points.Add(new Point3D(x, y, z - sideLength));
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

        public void Rotate(float rotationAngleDegree, int rotationAxis)
        {
            Matrix4x4 rotationMatrix;

            var degreeToRadians = Math.PI / 180;

            float sin = (float)Math.Sin(degreeToRadians * rotationAngleDegree);
            float cos = (float)Math.Cos(degreeToRadians * rotationAngleDegree);

            if (rotationAxis == 0)
            {
                rotationMatrix = new Matrix4x4
                    (
                        1, 0.0f, 0.0f, 1,
                        0, +cos, +sin, 0,
                        0, -sin, +cos, 0,
                        0, 0.0f, 0.0f, 1
                    );

                Transform(rotationMatrix);
            }
            else if (rotationAxis == 1)
            {
                rotationMatrix = new Matrix4x4
                    (
                        +cos, 0, -sin, 0,
                        0.0f, 1, 0.0f, 0,
                        +sin, 0, +cos, 0,
                        0.0f, 0, 0.0f, 1
                    );

                Transform(rotationMatrix);
            }
            else if (rotationAxis == 2)
            {
                rotationMatrix = new Matrix4x4
                    (
                        +cos, +sin, 0, 0,
                        -sin, +cos, 0, 0,
                        0.0f, 0.0f, 1, 0,
                        0.0f, 0.0f, 0, 1
                    );

                Transform(rotationMatrix);
            }
            else
            {
                return;
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
                var a = A;
                var c = C;

                return new Point3D(
                    (a.X + c.X) / 2,
                    (a.Y + c.Y) / 2,
                    (a.Z + c.Z) / 2
                    );
            }
        }

    }
}
