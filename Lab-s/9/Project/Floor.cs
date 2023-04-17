using System.Numerics;

namespace Project
{
    public class Floor3D : IObject3D
    {
        private List<Square3D> _cells;

        public Square3D Border { get; private set; }

        public Point3D A => Border.A;
        public Point3D B => Border.B;
        public Point3D C => Border.C;
        public Point3D D => Border.D;

        public Floor3D(Point3D floorCenter, float sideLength, int cellsAmountInRow = 8)
        {
            var half = sideLength / 2;

            Point3D leftUpPoint = new Point3D(
                floorCenter.X - half,
                floorCenter.Y,
                floorCenter.Z + half
                );

            Border = new Square3D(leftUpPoint, sideLength);

            _cells = new List<Square3D>(cellsAmountInRow * cellsAmountInRow);

            float squareSideLength = sideLength / cellsAmountInRow;
            Point3D point = leftUpPoint;

            for (int Z = 0; Z < cellsAmountInRow; Z++)
            {
                for (int X = 0; X < cellsAmountInRow; X++)
                {
                    var square = new Square3D(point, squareSideLength);
                    square.Translate(X * squareSideLength, 0, -Z * squareSideLength);

                    _cells.Add(square);
                }
            }
        }
    
        /// <summary>
        /// Floor lines for floor drawing
        /// </summary>
        public List<(Point3D point1, Point3D point2)> Grid
        {
            get
            {
                var cellsAmount = _cells.Count;
                var cellsAmountInRow = (int)Math.Sqrt(cellsAmount);

                var res = new List<(Point3D point1, Point3D point2)>(Border.Points.Count + (cellsAmountInRow - 1) * 2)
                {
                    (A, B),
                    (B, C),
                    (C, D),
                    (D, A)
                };

                //var a = A.Clone;
                //var b = B.Clone;
                //var d = D.Clone;

                //var cellSideLength = (int)Vector3.Distance(a.Vector3, b.Vector3) / _cells.Count;


                // Horizontals
                for (int i = 1; i < cellsAmountInRow; i++)
                {
                    var p1 = _cells[i * cellsAmountInRow].A;
                    var p2 = _cells[(i + 1) * cellsAmountInRow - 1].B;

                    res.Add((p1, p2));
                }

                int lastRow = cellsAmount - cellsAmountInRow;

                // Verticals
                for (int i = 1; i < cellsAmountInRow; i++)
                {
                    var p1 = _cells[i].A;
                    var p2 = _cells[lastRow + (i - 1)].C;

                    res.Add((p1, p2));
                }

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

        /// <summary>
        /// List of floor polygons
        /// </summary>
        /// <param name="r"> Focus distance? Something... </param>
        /// <param name="axis"> Projection Axis <br/> Axis Z - 0 <br/> Axis Y - 1 <br/> Axis X - 2 </param>
        public List<PointF[]> GetPolygonPointsInCentralProjection(float r = 0.01f, int axis = 0)
        {
            var cellsAmount = _cells.Count;

            List<PointF[]> res = new List<PointF[]>(cellsAmount);

            for (int i = 0; i < cellsAmount; i++)
            {
                res.Add(_cells[i].GetPolygonPointsInCentralProjection(r, axis));
            }

            return res;
        }
    }
}