using System.Numerics;

namespace Project
{
    public class Floor3D : IObject3D
    {
        private List<Square3D> _cells = new List<Square3D>();

        public Square3D Border { get; } = new Square3D();

        public Point3D A => Border.A;
        public Point3D B => Border.B;
        public Point3D C => Border.C;
        public Point3D D => Border.D;

        public Floor3D(Point3D floorCenter, float sideLength, int cellsAmountInRow = 8)
        {
            var half = sideLength / 2f;

            var x = floorCenter.X;
            var y = floorCenter.Y;
            var z = floorCenter.Z;

            Border.Points.Add(new Point3D(x - half, y, z + half));
            Border.Points.Add(new Point3D(x + half, y, z + half));
            Border.Points.Add(new Point3D(x + half, y, z - half));
            Border.Points.Add(new Point3D(x - half, y, z - half));

            float squareSideLength = sideLength / cellsAmountInRow;
            Point3D point = A;

            for (int Z = 0; Z < cellsAmountInRow; Z++)
            {
                for (int X = 0; X < cellsAmountInRow; X++)
                {
                    var square = new Square3D(point, squareSideLength);
                    square.Translate(X * squareSideLength, 0, Z * squareSideLength);

                    _cells.Add(square);
                }
            }
        }

        /// <summary>
        /// Floor edges as list of pairs of points of cells
        /// </summary>
        public List<(Point3D point1, Point3D point2)> Edges
        {
            get
            {
                var res = new List<(Point3D point1, Point3D point2)>();

                foreach (var square in _cells)
                {
                    res.AddRange(square.Edges);
                }

                return res;
            }
        }
    
        /// <summary>
        /// Floor lines for floor drawing
        /// </summary>
        public List<(Point3D point1, Point3D point2)> Grid
        {
            get
            {
                var cellsAmountInRow = (int)Math.Sqrt(_cells.Count);

                var a = A;
                var b = B;
                var d = D;

                var cellsAmount = _cells.Count - 1;
                var cellSideLength = (int)Vector3.Distance(a.Vector3, b.Vector3) / cellsAmountInRow;

                var res = new List<(Point3D point1, Point3D point2)>(Border.Points.Count + (cellsAmountInRow - 1) * 2)
                {
                    (A, B),
                    (B, C),
                    (C, D),
                    (D, A)
                };

                // Horizontals
                for (int i = 1; i < cellsAmountInRow; i++)
                {
                    var p1 = _cells[i * cellSideLength].D;
                    var p2 = _cells[(i + 1) * cellSideLength - 1].C;

                    res.Add((p1, p2));
                }

                //// Verticals
                //for (int i = 1; i < cellsAmountInRow; i++)
                //{
                //    var Dx = i * cellSideLength;

                //    var p1 = new Vector3(a.X + Dx, a.Y, a.Z);
                //    var p2 = new Vector3(d.X + Dx, d.Y, d.Z);

                //    res.Add((p1, p2));
                //}

                return res;
            }
        }

        /// <summary>
        /// Rotate floor around a center point by inputted angle on inputted Axis
        /// </summary>
        /// <param name="centerPoint"> The point around which the rotation will be reproduced </param>
        /// <param name="rotationAngleDegree"> Rotation angle in degrees </param>
        /// <param name="rotationAxis"> The axis along which the rotation will be reproduced <br/>
        /// Axis X - 0 <br/> Axis Y - 1 <br/> Axis Z - 2 </param>
        public void RotateAt(Point3D centerPoint, 
            float rotationAngleDegree, int rotationAxis = 0)
        {
            Border.RotateAt(centerPoint, rotationAngleDegree, rotationAxis);

            Parallel.ForEach(_cells, square =>
            {
                square.RotateAt(centerPoint, rotationAngleDegree, rotationAxis);
            });
        }

        public void Translate(float Dx = 0, float Dy = 0, float Dz = 0)
        {
            Border.Translate(Dx, Dy, Dz);

            Parallel.ForEach(_cells, square =>
            {
                square.Translate(Dx, Dy, Dz);
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
            Parallel.ForEach(Border.Points, point =>
            {
                point.Transform(transformMatrix);
            });

            Parallel.ForEach(_cells, square =>
            {
                square.Transform(transformMatrix);
            });
        }

        /// <summary>
        /// Center point of floor
        /// </summary>
        public Point3D CenterPoint => Border.CenterPoint;
    }
}