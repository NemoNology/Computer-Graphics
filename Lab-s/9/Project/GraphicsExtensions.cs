using System.Numerics;

namespace WF
{
    internal class GraphicsExtensions
    {
        /// <summary>
        /// Transform 3d point to 4d point for future manipulations
        /// </summary>
        public Vector4 Vector3ToVector4(Vector3 v)
        {
            return new Vector4(v, 1);
        }

        /// <param name="r"> Coefficient: 1 / k - Focus distance? </param>
        /// <param name="axis"> 0 - Z Axis <br/> 1 - Y Axis <br/> 2 - X Axis </param>
        /// <returns> Matrix for transformation by chosen axis </returns>
        public Matrix4x4 PerspectiveMatrix(float r, int axis = 0)
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
        public Vector3 Vector4ToVector3(Vector4 v)
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
        public Vector3 TransformVector(Vector3 v, float r, int axis = 0)
        {
            return Vector4ToVector3(Vector4.Transform
                (Vector3ToVector4(v), 
                PerspectiveMatrix(r, axis)
                ));
        }



    }
}
