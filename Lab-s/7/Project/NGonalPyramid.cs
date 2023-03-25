using System.Numerics;

namespace Project
{
    public class NGonalPyramid
    {
        public List<Vector3> Points { get; } = new List<Vector3>();

        public Vector3 PyramidBaseCenterPoint { get; private set; }

        public NGonalPyramid()
        {
            Points.Add(new Vector3(0, 3, 0));
            Points.Add(new Vector3(0, 0, 1));
            Points.Add(new Vector3(1, 0, 0));
            Points.Add(new Vector3(0, 0, -1));
            Points.Add(new Vector3(-1, 0, 0));
        }

        public NGonalPyramid(Vector3 pyramidBaseCenter, float height, float radius, int anglesAmount)
        {
            var x = pyramidBaseCenter.X;
            var y = pyramidBaseCenter.Y;
            var z = pyramidBaseCenter.Z + radius;

            PyramidBaseCenterPoint = pyramidBaseCenter;

            Points.Add(new Vector3(x, y + height, z - radius));

            for (var i = 1; i < anglesAmount; i++)
            {
                Points.Add(new Vector3(x, y, z));
            }

            PlaceStartPoints(pyramidBaseCenter, 360f / anglesAmount);
        }

        private void PlaceStartPoints(Vector3 pyramidBaseCenter, float angle)
        {
            var forBoth = Math.PI / 180 * angle;

            var z = pyramidBaseCenter.Z;
            var x = pyramidBaseCenter.X;

            for (int i = 1; i < Points.Count; i++)
            {
                var sin = (float)Math.Sin(forBoth * i);
                var cos = (float)Math.Cos(forBoth * i);

                var Z = (Points[i].Z - z) * cos - (Points[i].X - x) * sin - z;
                var X = (Points[i].Z - z) * sin + (Points[i].X - x) * cos - x;

                Points[i] = new Vector3(X, Points[i].Y, Z);
            }
        }

        /// <summary>
        /// Rotate Pyramid
        /// </summary>
        /// <param name="rotationAxis"> 0 - X <br/> 1 - Y <br/> 2 - Z </param>
        public void RotateAt(Vector3 rotationPoint, float angleDegree, byte rotationAxis = 0)
        {
            if (rotationAxis > 2)
            {
                return;
            }

            var angle = (Math.PI / 180) * angleDegree;

            var sin = (float)Math.Sin(angle);
            var cos = (float)Math.Cos(angle);

            var x = rotationPoint.X;
            var y = rotationPoint.Y;
            var z = rotationPoint.Z;

            if (rotationAxis == 0) // X
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    var Z = (Points[i].Z - z) * cos - (Points[i].Y - y) * sin - z;
                    var Y = (Points[i].Z - z) * sin + (Points[i].Y - y) * cos - y;

                    Points[i] = new Vector3(Points[i].X, Y, Z);
                }
            }
            else if (rotationAxis == 1) // Y
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    var Z = (Points[i].Z - z) * cos - (Points[i].Y - y) * sin - z;
                    var X = (Points[i].Z - z) * sin + (Points[i].X - x) * cos - x;

                    Points[i] = new Vector3(X, Points[i].Y, Z);
                }
            }
            else // rotationAxis == 2 - Z
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    var X = (Points[i].Z - z) * sin + (Points[i].X - x) * cos - x;
                    var Y = (Points[i].Z - z) * sin + (Points[i].Y - y) * cos - y;

                    Points[i] = new Vector3(X, Y, Points[i].Z);
                }
            }
        }

        public void Transform(int Dx, int Dy, int Dz)
        {
            for (var i = 0; i < Points.Count; i++)
            {
                Points[i] = new Vector3(
                    Points[i].X + Dx,
                    Points[i].Y + Dy,
                    Points[i].Z + Dz
                    );
            }
        }

        public List<Tuple<Vector3, Vector3>> Edges
        {
            get
            {
                var up = new List<Tuple<Vector3, Vector3>>();

                for (var i = 1; i < Points.Count; i++)
                {
                    up.Add(new Tuple<Vector3, Vector3>(Points[i], Points[0]));
                }

                var down = new List<Tuple<Vector3, Vector3>>();

                for (var i = 1; i < Points.Count - 1; i++)
                {
                    down.Add(new Tuple<Vector3, Vector3>(Points[i], Points[i + 1]));
                }

                down.Add(new Tuple<Vector3, Vector3>(Points.Last(), Points[1]));

                down.AddRange(up);

                return down;
            }
        }

        public int AmountOfEdges => Points.Count - 1;
    }
}