using System.Collections.Generic;
using System.Numerics;

namespace WF
{
    
    internal class Cube
    {
        public Vector3 A1 { get; set; }
        public Vector3 A2 { get; set; }
        public Vector3 A3 { get; set; }
        public Vector3 A4 { get; set; }
        public Vector3 B1 { get; set; }
        public Vector3 B2 { get; set; }
        public Vector3 B3 { get; set; }
        public Vector3 B4 { get; set; }

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
            var HalfSideLenght = sideLength / 2f;

            A1 = new Vector3(center.X - HalfSideLenght, center.Y + HalfSideLenght, center.Z - HalfSideLenght);
            A2 = new Vector3(center.X - HalfSideLenght, center.Y + HalfSideLenght, center.Z + HalfSideLenght);
            A3 = new Vector3(center.X + HalfSideLenght, center.Y + HalfSideLenght, center.Z + HalfSideLenght);
            A4 = new Vector3(center.X + HalfSideLenght, center.Y + HalfSideLenght, center.Z - HalfSideLenght);

            B1 = new Vector3(center.X - HalfSideLenght, center.Y - HalfSideLenght, center.Z - HalfSideLenght);
            B2 = new Vector3(center.X - HalfSideLenght, center.Y - HalfSideLenght, center.Z + HalfSideLenght);
            B3 = new Vector3(center.X + HalfSideLenght, center.Y - HalfSideLenght, center.Z + HalfSideLenght);
            B4 = new Vector3(center.X + HalfSideLenght, center.Y - HalfSideLenght, center.Z - HalfSideLenght);
        }

        /// <summary>
        /// Not Completed...
        /// </summary>
        public Vector3 CenterPoint
        {
            get
            {
                return new Vector3((A4.X - A1.X) * 0.5f, (A1.Y - B1.Y) * 0.5f, (A2.Z - A1.Z) * 0.5f);
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
    }
}
