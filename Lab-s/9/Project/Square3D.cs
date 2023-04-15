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
            Points.Add(new Vector3(-0.5f, 0, 0.5f));
            Points.Add(new Vector3(0.5f, 0, 0.5f));
            Points.Add(new Vector3(0.5f, 0, -0.5f));
            Points.Add(new Vector3(-0.5f, 0, -0.5f));
        }

        public Square3D(Vector3 squareLeftUpPoint, float sideLength)
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

        public void Translate(float Dx, float Dy = 0, float Dz = 0)
        {
            Parallel.ForEach(Points, point =>
            {
                point.Translate(Dx, Dy, Dz);
            });
        }

        /// <summary>
        /// Rotate square around a rotation center point by inputted angle on inputted Axis
        /// </summary>
        /// <param name="rotationCenterPoint"> The point around which the square revolves </param>
        /// <param name="rotationAngleDegree"> Rotation angle in degrees </param>
        /// <param name="rotationAxis"> Axis X - 0 <br/> Axis Y - 1 <br/> Axis Z - 2 </param>
        public void RotateAt(Point3D rotationCenterPoint,
            float rotationAngleDegree, int rotationAxis)
        {
            Rotate(rotationAngleDegree, rotationAxis);
            Translate(rotationCenterPoint.X, rotationCenterPoint.Y, rotationCenterPoint.Z);
        }

        public void Rotate(float rotationAngleDegree, int rotationAxis)
        {
            Parallel.ForEach(Points, point =>
            {
                point.Rotate(rotationAngleDegree, rotationAxis);
            });
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
