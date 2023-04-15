using System.Numerics;

namespace Project
{
    public class Square3D
    {
        public List<Vector3> Points { get; } = new List<Vector3>(4);

        public Vector3 A => Points[0];
        public Vector3 B => Points[1];
        public Vector3 C => Points[2];
        public Vector3 D => Points[3];

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

            Points.Add(new Vector3(x, y, z));
            Points.Add(new Vector3(x + sideLength, y, z));
            Points.Add(new Vector3(x + sideLength, y, z - sideLength));
            Points.Add(new Vector3(x, y, z - sideLength));
        }

        /// <summary>
        /// Square edges as list of pairs of points
        /// </summary>
        public List<Tuple<Vector3, Vector3>> Edges
        {
            get
            {
                return new List<Tuple<Vector3, Vector3>> {
                    new Tuple<Vector3, Vector3>(A, B),
                    new Tuple<Vector3, Vector3>(B, C),
                    new Tuple<Vector3, Vector3>(C, D),
                    new Tuple<Vector3, Vector3>(D, A)
                };
            }
        }

        /// <summary>
        /// Move square by Dx, Dy, Dz
        /// </summary>
        /// <param name="Dx"> The value, along the X axis, by which the square will move </param>
        /// <param name="Dy"> The value, along the Y axis, by which the square will move </param>
        /// <param name="Dz"> The value, along the Z axis, by which the square will move </param>
        public void Translate(float Dx, float Dy = 0, float Dz = 0)
        {
            var translateMatrix = new Matrix4x4(

                1,  0,  0,  0,
                0,  1,  0,  0,
                0,  0,  1,  0,
                Dx, Dy, Dz, 1
            );

            for (int i = 0; i < Points.Count; i++)
            {
                var buffer = new Vector4(Points[i], 1);
                buffer = Vector4.Transform(buffer, translateMatrix);
                Points[i] = new Vector3(
                    buffer.X,
                    buffer.Y,
                    buffer.Z
                    );
            }
        }

        /// <summary>
        /// Move square by translation matrix
        /// </summary>
        public void Translate(Matrix4x4 translateMatrix)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                var buffer = new Vector4(Points[i], 1);
                buffer = Vector4.Transform(buffer, translateMatrix);
                Points[i] = new Vector3(
                    buffer.X,
                    buffer.Y,
                    buffer.Z
                    );
            }
        }

        /// <summary>
        /// Rotation of a square around a rotation center point by certain angles
        /// </summary>
        /// <param name="rotationCenterPoint"> The point around which the square revolves </param>
        /// <param name="angleDegreeByX"> Angle in degrees along the X axis by which the square will rotate </param>
        /// <param name="angleDegreeByY"> Angle in degrees along the Y axis by which the square will rotate </param>
        /// <param name="angleDegreeByZ"> Angle in degrees along the Z axis by which the square will rotate </param>
        public void RotateAt(Vector3 rotationCenterPoint, float angleDegreeByX = 0,
            float angleDegreeByY = 0, float angleDegreeByZ = 0)
        {
            double rad = -Math.PI / 180;

            float cosX = (float)Math.Cos(rad * angleDegreeByX);
            float sinX = (float)Math.Sin(rad * angleDegreeByX);

            float cosY = (float)Math.Cos(rad * angleDegreeByY);
            float sinY = (float)Math.Sin(rad * angleDegreeByY);

            float cosZ = (float)Math.Cos(rad * angleDegreeByZ);
            float sinZ = (float)Math.Sin(rad * angleDegreeByZ);

            var rotationMatrixX = new Matrix4x4(
                1, 0_00f, 0_00f, 0,
                0, cosX,  sinX,  0,
                0, -sinX, cosX,  0,
                0, 0_00f, 0_00f, 1
            );

            var rotationMatrixY = new Matrix4x4(
                cosY,  0, sinY,  0,
                0_00f, 1, 0_00f, 0,
                -sinY, 0, cosY,  0,
                0_00f, 0, 0_00f, 1
            );

            var rotationMatrixZ = new Matrix4x4(
                 cosZ, sinZ,  0, 0,
                -sinZ, cosZ,  0, 0,
                0_00f, 0_00f, 1, 0,
                0_00f, 0_00f, 0, 1
            );

            Matrix4x4 rotationMatrix = 
                rotationMatrixX * rotationMatrixY * rotationMatrixZ;

            for (int i = 0; i < Points.Count; i++)
            {
                var buffer = new Vector4(Points[i], 1);
                buffer = Vector4.Transform(buffer, rotationMatrix);
                Points[i] = new Vector3(
                    buffer.X,
                    buffer.Y,
                    buffer.Z
                    );
            }

            var translateMatrix = new Matrix4x4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                rotationCenterPoint.X, rotationCenterPoint.Y, rotationCenterPoint.Z, 1
            );

            Translate(translateMatrix);
        }

        /// <summary>
        /// Rotation of a square by rotation matrix
        /// </summary>
        public void Rotate(Matrix4x4 rotationMatrix)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                var buffer = new Vector4(Points[i], 1);
                buffer = Vector4.Transform(buffer, rotationMatrix);
                Points[i] = new Vector3(
                    buffer.X,
                    buffer.Y,
                    buffer.Z
                    );
            }
        }
    }
}
