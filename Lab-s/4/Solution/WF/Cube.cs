﻿using System.Numerics;

namespace WF
{
    internal class Cube
    {
        /// <summary>
        /// <b>Points structure: </b><br/>
        /// A2 A3 <br/>
        /// A1 A4 <br/>
        /// <br/>
        /// B2 B3 <br/>
        /// B1 B4 
        /// </summary>
        public Vector3 Center { get; set; }
        public ushort SideLength { get; set; }
        
        /// <summary>
        /// Rotation that change points on X & Z - axises
        /// </summary>
        public ushort RotationByAxisX { get; set; }

        /// <summary>
        /// Rotation that change points on Y & Z - axises
        /// </summary>
        public ushort RotationByAxisY { get; set; }

        /// <summary>
        /// Rotation that change points on X & Y - axises
        /// </summary>
        public ushort RotationByAxisZ { get; set; }

        private float HalfSideLenght => SideLength / 2f;

        /// <summary>
        /// See Center commentary...
        /// </summary>
        public Vector3 A1
        {
            get
            {
                return new Vector3(Center.X - HalfSideLenght, Center.Y + HalfSideLenght, Center.Z - HalfSideLenght);
            }
        }

        /// <summary>
        /// See Center commentary...
        /// </summary>
        public Vector3 A2
        {
            get
            {
                return new Vector3(Center.X - HalfSideLenght, Center.Y + HalfSideLenght, Center.Z + HalfSideLenght);
            }
        }

        /// <summary>
        /// See Center commentary...
        /// </summary>
        public Vector3 A3
        {
            get
            {
                return new Vector3(Center.X + HalfSideLenght, Center.Y + HalfSideLenght, Center.Z + HalfSideLenght);
            }
        }

        /// <summary>
        /// See Center commentary...
        /// </summary>
        public Vector3 A4
        {
            get
            {
                return new Vector3(Center.X + HalfSideLenght, Center.Y + HalfSideLenght, Center.Z - HalfSideLenght);
            }
        }

        /// <summary>
        /// See Center commentary...
        /// </summary>
        public Vector3 B1
        {
            get
            {
                return new Vector3(Center.X - HalfSideLenght, Center.Y - HalfSideLenght, Center.Z - HalfSideLenght);
            }
        }

        /// <summary>
        /// See Center commentary...
        /// </summary>
        public Vector3 B2
        {
            get
            {
                return new Vector3(Center.X - HalfSideLenght, Center.Y - HalfSideLenght, Center.Z + HalfSideLenght);
            }
        }

        /// <summary>
        /// See Center commentary...
        /// </summary>
        public Vector3 B3
        {
            get
            {
                return new Vector3(Center.X + HalfSideLenght, Center.Y - HalfSideLenght, Center.Z + HalfSideLenght);
            }
        }

        /// <summary>
        /// See Center commentary...
        /// </summary>
        public Vector3 B4
        {
            get
            {
                return new Vector3(Center.X + HalfSideLenght, Center.Y - HalfSideLenght, Center.Z - HalfSideLenght);
            }
        }
    }
}
