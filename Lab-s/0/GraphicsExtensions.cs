using System.Numerics;

namespace GraphicUnit
{
    public class GraphicsExtensions
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
        /// Rotate Object3D around a Start of coordinates (0, 0, 0) by inputted angle on inputted Axis
        /// </summary>
        /// <param name="rotationPoint"> The point around which the Object3D revolves </param>
        /// <param name="rotationAngleDegree"> Rotation angle in degrees </param>
        /// <param name="rotationAxis"> Axis X - 0 <br/> Axis Y - 1 <br/> Axis Z - 2 </param>
        public void Rotate(float rotationAngleDegree, int rotationAxis);

        /// <summary>
        /// Transform Object3D by transform matrix
        /// </summary>
        /// <param name="transformMatrix"> Matrix with which Object3D will be transformed </param>
        public void Transform(Matrix4x4 transformMatrix);

    }

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
                projectionMatrix = new Matrix4x4(
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

        /// <summary>
        /// Rotate point around a center point by inputted angle on inputted Axis
        /// </summary>
        /// <param name="centerPoint"> The point around which the rotation will be reproduced </param>
        /// <param name="rotationAngleDegree"> Rotation angle in degrees </param>
        /// <param name="rotationAxis"> The axis along which the rotation will be reproduced <br/>
        /// Axis X - 0 <br/> Axis Y - 1 <br/> Axis Z - 2 </param>
        public void RotateAt(Point3D centerPoint, float rotationAngleDegree, int rotationAxis = 0)
        {
            var x = centerPoint.X;
            var y = centerPoint.Y;
            var z = centerPoint.Z;

            var degreeToRadians = Math.PI / 180;

            float sin = (float)Math.Sin(degreeToRadians * rotationAngleDegree);
            float cos = (float)Math.Cos(degreeToRadians * rotationAngleDegree);

            // X
            if (rotationAxis == 0)
            {
                Z = (Z - z) * cos - (Y - y) * sin + z;
                Y = (Z - z) * sin + (Y - y) * cos + y;
            }
            // Y
            else if (rotationAxis == 1)
            {
                X = (Z - z) * cos - (X - x) * sin + x;
                Z = (Z - z) * sin + (X - x) * cos + z;
            }
            // Z
            else if (rotationAxis == 2)
            {
                X = (X - x) * cos - (Y - y) * sin + x;
                Y = (X - x) * sin + (Y - y) * cos + y;
            }
            else
            {
                return;
            }

        }

    }

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
