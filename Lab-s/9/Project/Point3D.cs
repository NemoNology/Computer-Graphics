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
        public (float X, float Y) GetCentralProjection(
            float r = 0.01f, int axis = 0)
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
            }
            else if (axis == 1)
            {
                projectionMatrix = new Matrix4x4(
                        1, 0, 0, 0,
                        0, 0, 0, r,
                        0, 0, 1, 0,
                        0, 0, 0, 1
                        );
            }
            else if (axis == 2)
            {
                projectionMatrix = new Matrix4x4(
                        0, 0, 0, r,
                        0, 1, 0, 0,
                        0, 0, 1, 0,
                        0, 0, 0, 1
                        );
            }
            else
            {
                return (0, 0);
            }

            pointBuffer = Vector4.Transform(
                new Vector4(X, Y, Z, 1),
                projectionMatrix
                );

            if (pointBuffer.W == 0)
            {
                return (0, 0);
            }

            return (pointBuffer.X / pointBuffer.W,
                pointBuffer.Y / pointBuffer.W);
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

        /// <summary>
        /// Rotate point around a center point by inputted angle on inputted Axis
        /// </summary>
        /// <param name="rotationCenterPoint"> The point around which the rotation will be reproduced </param>
        /// <param name="rotationAngleDegree"> Rotation angle in degrees </param>
        /// <param name="rotationAxis"> The axis along which the rotation will be reproduced <br/>
        /// Axis X - 0 <br/> Axis Y - 1 <br/> Axis Z - 2 </param>
        public void RotateAt(Point3D rotationCenterPoint, 
            float rotationAngleDegree, int rotationAxis = 0)
        {
            var x = rotationCenterPoint.X;
            var y = rotationCenterPoint.Y;
            var z = rotationCenterPoint.Z;

            var angle = (Math.PI / 180) * rotationAngleDegree;

            var sin = (float)Math.Sin(angle);
            var cos = (float)Math.Cos(angle);

            var buffX = X;
            var buffY = Y;
            var buffZ = Z;

            // X
            if (rotationAxis == 0)
            {
                Z = (buffZ - z) * cos - (buffY - y) * sin + z;
                Y = (buffZ - z) * sin + (buffY - y) * cos + y;
            }
            // Y
            else if (rotationAxis == 1)
            {
                Z = (buffZ - z) * cos - (buffX - x) * sin + z;
                X = (buffZ - z) * sin + (buffX - x) * cos + x;
            }
            // Z
            else if (rotationAxis == 2)
            {
                X = (buffX - x) * cos - (buffY - y) * sin + x;
                Y = (buffX - x) * sin + (buffY - y) * cos + y;
            }
            else
            {
                return;
            }

        }

    }
}
