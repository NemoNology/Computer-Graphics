using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace WF
{

    internal class Cube
    {
        /// <summary>
        /// Points in next order: A1, A2, A3, A4, B1, B2, B3, B4 <br/>
        /// <i> For points structure see PointsStructurePicture description </i>
        /// </summary>
        public List<Vector3> Points { get; set; }

        public Vector3 A1 => Points[0];
        public Vector3 A2 => Points[1];
        public Vector3 A3 => Points[2];
        public Vector3 A4 => Points[3];
        public Vector3 B1 => Points[4];
        public Vector3 B2 => Points[5];
        public Vector3 B3 => Points[6];
        public Vector3 B4 => Points[7];

        /// <summary>
        /// <b>Points structure: </b><br/>
        /// <code>
        /// ######################
        /// #######A2--------A3###
        /// #####//||######//||###
        /// ###A1--------A4##||###
        /// ###||##||####||##||###
        /// ###||##B2----||--B3###
        /// ###||//######||//#####
        /// ###B1--------B4#######
        /// ######################
        /// </code>
        /// </summary>
        public const char PointsStructurePicture = '-';

        public Cube(Vector3 center, ushort sideLength)
        {
            var halfSideLength = sideLength / 2f;

            Points = new List<Vector3>(8)
            {   
                // A1..A4
                new Vector3(center.X - halfSideLength, center.Y + halfSideLength, center.Z - halfSideLength),
                new Vector3(center.X - halfSideLength, center.Y + halfSideLength, center.Z + halfSideLength),
                new Vector3(center.X + halfSideLength, center.Y + halfSideLength, center.Z + halfSideLength),
                new Vector3(center.X + halfSideLength, center.Y + halfSideLength, center.Z - halfSideLength),

                // B1..B4
                new Vector3(center.X - halfSideLength, center.Y - halfSideLength, center.Z - halfSideLength),
                new Vector3(center.X - halfSideLength, center.Y - halfSideLength, center.Z + halfSideLength),
                new Vector3(center.X + halfSideLength, center.Y - halfSideLength, center.Z + halfSideLength),
                new Vector3(center.X + halfSideLength, center.Y - halfSideLength, center.Z - halfSideLength)
            };
        }

        /// <summary>
        /// Not Completed...
        /// </summary>
        public Vector3 CenterPoint
        {
            get
            {
                var halfSideLength = Vector3.Distance(A1, A2) / 2;

                return new Vector3();
            }
        }

        /// <summary>
        /// List of cube edges, where item (Vector3) - 3D line; <br/>
        /// Item1.x, y, z - first point of line, Item2.x, y, z - second; 
        /// </summary>
        public List<Tuple<Vector3, Vector3>> Edges
        {
            get
            {
                return new List<Tuple<Vector3, Vector3>> {
                    new Tuple<Vector3, Vector3>(A1, A2),
                    new Tuple<Vector3, Vector3>(A2, A3),
                    new Tuple<Vector3, Vector3>(A3, A4),
                    new Tuple<Vector3, Vector3>(A4, A1),

                    new Tuple<Vector3, Vector3>(B1, B2),
                    new Tuple<Vector3, Vector3>(B2, B3),
                    new Tuple<Vector3, Vector3>(B3, B4),
                    new Tuple<Vector3, Vector3>(B4, B1),

                    new Tuple<Vector3, Vector3>(A1, B1),
                    new Tuple<Vector3, Vector3>(A2, B2),
                    new Tuple<Vector3, Vector3>(A3, B3),
                    new Tuple<Vector3, Vector3>(A4, B4),
                };
            }
        }

        /// <summary>
        /// Rotate cube
        /// </summary>
        /// <param name="rotationAxis"> 0 - X <br/> 1 - Y <br/> 2 - Z </param>
        public void RotateAt(Vector3 rotationPoint, int angleDegree, byte rotationAxis = 0)
        {
            if (rotationAxis > 2 || rotationAxis < 0)
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
                    var Z = (Points[i].Z - z) * cos -(Points[i].Y - y) * sin + z;
                    var Y = (Points[i].Z - z) * sin + (Points[i].Y - y) * cos + y;

                    Points[i] = new Vector3(Points[i].X, Y, Z);
                }
            }
            else if (rotationAxis == 1) // Y
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    var Z = (Points[i].Z - z) * cos - (Points[i].X - x) * sin + z;
                    var X = (Points[i].Z - z) * sin + (Points[i].X - x) * cos + x;

                    Points[i] = new Vector3(X, Points[i].Y, Z);
                }
            }
            else // rotationAxis == 2 - Z
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    var X = (Points[i].X - x) * cos - (Points[i].Y - y) * sin + x;
                    var Y = (Points[i].X - x) * sin + (Points[i].Y - y) * cos + y;

                    Points[i] = new Vector3(X, Y, Points[i].Z);
                }
            }
        }
    }
}
