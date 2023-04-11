using System.Numerics;

namespace Project
{
    public class Square3D
    {
        public List<Vector3> Points { get; } = new List<Vector3>(4);

        public Vector3 A => Points[0];
        public Vector3 B => Points[1];
        public Vector3 C => Points[2];
        public Vector3 D => Points[3];

        public Square3D()
        {
            Points.Add(new Vector3(-0.5f, 0, 0.5f));
            Points.Add(new Vector3(0.5f, 0, 0.5f));
            Points.Add(new Vector3(0.5f, 0, -0.5f));
            Points.Add(new Vector3(-0.5f, 0, -0.5f));
        }

    
        public Square3D(Vector3 squareLeftUpPoint, float sideLength)
        {
            var x = squareLeftUpPoint.X;
            var y = squareLeftUpPoint.Y;
            var z = squareLeftUpPoint.Z;

            Points.Add(new Vector3(x, y, z));
            Points.Add(new Vector3(x + sideLength, y, z));
            Points.Add(new Vector3(x + sideLength, y, z - sideLength));
            Points.Add(new Vector3(x, y, z - sideLength));
        }

        public List<Tuple<Vector3, Vector3>> Edges
        {
            get
            {
                return new List<Tuple<Vector3, Vector3>> {
                    new Tuple<Vector3, Vector3>(A, B),
                    new Tuple<Vector3, Vector3>(B, C),
                    new Tuple<Vector3, Vector3>(C, D),
                    new Tuple<Vector3, Vector3>(D, A)
                };
            }
        }
    }
}
