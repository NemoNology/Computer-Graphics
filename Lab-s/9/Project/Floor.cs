using System.Numerics;

namespace Project
{
    public class Floor3D
    {
        private List<Square3D> _cells = new List<Square3D>();

        public List<Vector3> Points { get; } = new List<Vector3>(4);

        public Vector3 A => Points[0];
        public Vector3 B => Points[1];
        public Vector3 C => Points[2];
        public Vector3 D => Points[3];

        public Floor3D(Vector3 floorCenter, float sideLength, int cellsAmountInRow = 8)
        {
            var half = sideLength / 2f;

            var x = floorCenter.X;
            var y = floorCenter.Y;
            var z = floorCenter.Z;

            Points.Add(new Vector3(x - half, y, z - half));
            Points.Add(new Vector3(x + half, y, z - half));
            Points.Add(new Vector3(x + half, y, z + half));
            Points.Add(new Vector3(x - half, y, z + half));

            float squareSideLength = sideLength / cellsAmountInRow;
            Vector3 point = A;

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
        public List<Tuple<Vector3, Vector3>> Edges
        {
            get
            {
                var res = new List<Tuple<Vector3, Vector3>>();

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
        public List<Tuple<Vector3, Vector3>> Grid
        {
            get
            {
                var cellsAmountInRow = (int)Math.Sqrt(_cells.Count);

                var a = A;
                var b = B;
                var d = D;

                var cellSideLength = Vector3.Distance(a, b) / cellsAmountInRow;

                var res = new List<Tuple<Vector3, Vector3>>(Points.Count + (cellsAmountInRow - 1) * 2)
                {
                    new Tuple<Vector3, Vector3>(A, B),
                    new Tuple<Vector3, Vector3>(B, C),
                    new Tuple<Vector3, Vector3>(C, D),
                    new Tuple<Vector3, Vector3>(D, A)
                };

                // Horizontals
                for (int i = 1; i < cellsAmountInRow; i++)
                {
                    var Dz = i * cellSideLength;

                    var p1 = new Vector3(a.X, a.Y, a.Z + Dz);
                    var p2 = new Vector3(b.X, b.Y, b.Z + Dz);

                    res.Add(new Tuple<Vector3, Vector3>(p1, p2));
                }

                // Verticals
                for (int i = 1; i < cellsAmountInRow; i++)
                {
                    var Dx = i * cellSideLength;

                    var p1 = new Vector3(a.X + Dx, a.Y, a.Z);
                    var p2 = new Vector3(d.X + Dx, d.Y, d.Z);

                    res.Add(new Tuple<Vector3, Vector3>(p1, p2));
                }

                return res;
            }
        }

        /// <summary>
        /// Move floor by Dx, Dy, Dz
        /// </summary>
        /// <param name="Dx"> The value, along the X axis, by which the floor will move </param>
        /// <param name="Dy"> The value, along the Y axis, by which the floor will move </param>
        /// <param name="Dz"> The value, along the Z axis, by which the floor will move </param>
        public void Translate(float Dx, float Dy = 0, float Dz = 0)
        {
            var translateMatrix = new Matrix4x4(
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
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

            Parallel.ForEach(_cells, cell =>
            {
                cell.Translate(translateMatrix);
            });
        }

        /// <summary>
        /// Rotation of a floor around a rotation center point by certain angles
        /// </summary>
        /// <param name="rotationCenterPoint"> The point around which the floor revolves </param>
        /// <param name="angleDegreeByX"> Angle in degrees along the X axis by which the floor will rotate </param>
        /// <param name="angleDegreeByY"> Angle in degrees along the Y axis by which the floor will rotate </param>
        /// <param name="angleDegreeByZ"> Angle in degrees along the Z axis by which the floor will rotate </param>
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

            Parallel.ForEach(_cells, cell =>
            {
                cell.Rotate(rotationMatrix);
            });

            Translate(
                rotationCenterPoint.X, 
                rotationCenterPoint.Y, 
                rotationCenterPoint.Z);
        }
    
        public Vector3 CenterPoint
        {
            get
            {
                var a = A;
                var c = C;

                return new Vector3(
                    (a.X + c.X) / 2,
                    (a.Y + c.Y) / 2,
                    (a.Z + c.Z) / 2
                    );
            }
        }
    }
}