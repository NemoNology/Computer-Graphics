using System.Numerics;

namespace WF
{
    internal class GraphicsExtensions
    {
        /// <summary>
        /// Transform 3d point to 4d point for future manipulations
        /// </summary>
        public static Vector4 Vector3ToVector4(Vector3 v)
        {
            return new Vector4(v, 1);
        }

        /// <summary>
        /// Z - Axis 0, Y - Axis 1, X - Axis 2;
        /// </summary>
        /// <param name="r"> coefficient: 1 / k </param>
        public static Matrix4x4 PerspectiveMatrix(float r, int axis = 0)
        {
            switch (axis)
            {
                case 0:

                    return new Matrix4x4(
                        1, 0, 0, 0,
                        0, 1, 0, 0,
                        0, 0, 0, r,
                        0, 0, 0, 1
                        );

                case 1:

                    return new Matrix4x4(
                       1, 0, 0, 0,
                       0, 0, 0, r,
                       0, 0, 1, 0,
                       0, 0, 0, 1
                       );

                case 2:

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

    }
}
