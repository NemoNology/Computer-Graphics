using System.Numerics;

namespace Project
{
    public interface IObject3D
    {
        /// <summary>
        /// Move Object3D by Dx, Dy, Dz
        /// </summary>
        /// <param name="Dx"> The value, along the X axis, by which the Object3D will move </param>
        /// <param name="Dy"> The value, along the Y axis, by which the Object3D will move </param>
        /// <param name="Dz"> The value, along the Z axis, by which the Object3D will move </param>
        public void Translate(float Dx, float Dy, float Dz);

        /// <summary>
        /// Transform Object3D by transform matrix
        /// </summary>
        /// <param name="transformMatrix"> Matrix with which Object3D will be transformed </param>
        public void Transform(Matrix4x4 transformMatrix);

    }
}
