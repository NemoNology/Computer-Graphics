using System.Numerics;

namespace Project
{
    public class Point3D : IObject3D
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public void Translate(float Dx = 0, float Dy = 0, float Dz = 0)
        {
            X += Dx;
            Y += Dy;
            Z += Dz;
        }
        
        /// <summary>
        /// New Vector3 by XYZ values
        /// </summary>
        public Vector3 Vector3 => new Vector3(X, Y, Z);

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
            var transformedVector = 
                Vector4.Transform(
                    new Vector4(X, Y, Z, 1),
                    transformMatrix);

            X = transformedVector.X;
            Y = transformedVector.Y;
            Z = transformedVector.Z;
        }

        /// <summary>
        /// Return pair of new values, that should be used as central projection point
        /// </summary>
        /// <param name="r"> Focus distance? Center point something... </param>
        /// <param name="axis"> Axis by that will be transformed vector 
        /// <br/> Axis Z - 0 <br/> Axis Y - 1 <br/> Axis X - 2 </param>
        public (float X, float Y) GetCentralProjection(float r = 0.01f, int axis = 0)
        {
            Matrix4x4 projectionMatrix;
            Vector4 pointBuffer;

            if (axis == 0)
            {
                projectionMatrix =  new Matrix4x4(
                        1, 0, 0, 0,
                        0, 1, 0, 0,
                        0, 0, 0, r,
                        0, 0, 0, 1
                        );

                pointBuffer = Vector4.Transform(
                    new Vector4(X, Y, Z, 1),
                    projectionMatrix
                    );

                return (pointBuffer.X / pointBuffer.W, 
                    pointBuffer.Y / pointBuffer.W);
            }
            else if (axis == 1)
            {
                projectionMatrix = new Matrix4x4(
                        1, 0, 0, 0,
                        0, 0, 0, r,
                        0, 0, 1, 0,
                        0, 0, 0, 1
                        );

                pointBuffer = Vector4.Transform(
                    new Vector4(X, Y, Z, 1),
                    projectionMatrix
                    );

                return (pointBuffer.X / pointBuffer.W,
                    pointBuffer.Y / pointBuffer.W);
            }
            else if (axis == 2)
            {
                projectionMatrix = new Matrix4x4(
                        0, 0, 0, r,
                        0, 1, 0, 0,
                        0, 0, 1, 0,
                        0, 0, 0, 1
                        );

                pointBuffer = Vector4.Transform(
                    new Vector4(X, Y, Z, 1),
                    projectionMatrix
                    );

                return (pointBuffer.X / pointBuffer.W,
                    pointBuffer.Y / pointBuffer.W);
            }
            else
            {
                return (0, 0);
            }
        }

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

    }
}
