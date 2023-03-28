using System.Numerics;

namespace Project
{
    public class Square
    {
        public List<Vector2> Points { get; } = new List<Vector2>(4);

        public Vector2 A => Points[0];
        public Vector2 B => Points[1];
        public Vector2 C => Points[2];
        public Vector2 D => Points[3];

        public Square()
        {
            Points.Add(new Vector2(0, 0));
            Points.Add(new Vector2(1, 0));
            Points.Add(new Vector2(1, 1));
            Points.Add(new Vector2(0, 1));
        }

        public Square(Point squareCenter, float sideLength)
        {
            var halfSideLength = sideLength / 2;

            var x = squareCenter.X;
            var y = squareCenter.Y;

            Points.Add(new Vector2(x - halfSideLength, y - halfSideLength));
            Points.Add(new Vector2(x + halfSideLength, y - halfSideLength));
            Points.Add(new Vector2(x + halfSideLength, y + halfSideLength));
            Points.Add(new Vector2(x - halfSideLength, y + halfSideLength));
        }

        public void Translate(float x, float y)
        {
            for (int i = 0; i < Points.Count; i++)
            {
                Points[i] = new Vector2(Points[i].X + x, Points[i].Y + y);
            }
        }

        public List<Tuple<Vector2, Vector2>> Edges
        {
            get
            {
                return new List<Tuple<Vector2, Vector2>> {
                    new Tuple<Vector2, Vector2>(A, B),
                    new Tuple<Vector2, Vector2>(B, C),
                    new Tuple<Vector2, Vector2>(C, D),
                    new Tuple<Vector2, Vector2>(D, A)
                };
            }
        }


    }
}