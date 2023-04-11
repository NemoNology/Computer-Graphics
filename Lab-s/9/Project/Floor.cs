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

        public int CellsAmount { get; set; }

        public Floor3D(Vector3 floorCenter, float sideLength, int cellsAmountInRow = 8)
        {
            var half = sideLength / 2;

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
                    _cells.Add(new Square3D(point, squareSideLength));
                    point = new Vector3(
                        point.X * X,
                        y,
                        point.Z * Z 
                    );
                }
            }
        }

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
    }
}