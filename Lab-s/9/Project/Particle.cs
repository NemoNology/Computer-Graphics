namespace Project
{
    public class Particle
    {
        public Point3D Coordinates { get; set; }
        public Image Sprite { get; set; }
        public Point3D Velocity { get; set; }
        public Point3D Acceleration { get; set; }
        public byte Fading { get; set; }

        public Particle(
            Point3D coordinates,
            Image sprite,
            Point3D velocity,
            Point3D acceleration,
            byte fading
        )
        {
            Coordinates = coordinates;
            Sprite = sprite;
            Velocity = velocity;
            Acceleration = acceleration;
            Fading = fading;
        }

        /// <returns> <c> True </c>, if sprite is fully transparent <br/> False - otherwise </returns>
        public bool Move()
        {
            if (IsTransparent)
            {
                return true;
            }

            Coordinates += Velocity;
            Velocity += Acceleration;

            //Velocity = new Point3D(0, Velocity.Y, Velocity.Z);
            //Acceleration = new Point3D(0, Acceleration.Y, Acceleration.Z);

            //if (Velocity.Y < 0)
            //{
            //    Velocity = new Point3D(Velocity.X, 0, Velocity.Z);
            //    Acceleration = new Point3D(Acceleration.X, 0, Acceleration.Z);
            //}

            //Velocity = new Point3D(Velocity.X, Velocity.Y, 0);
            //Acceleration = new Point3D(Acceleration.X, Acceleration.Y, 0);

            Sprite = Fade();

            return IsTransparent;
        }

        private bool IsTransparent
        {
            get
            {
                var sprite = (Bitmap)Sprite;
                var h = sprite.Height;
                var w = sprite.Width;

                for (int x = 0; x < w; x++)
                {
                    for (int y = 0; y < h; y++)
                    {
                        var color = sprite.GetPixel(x, y);

                        if (color.A > 0)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        private Bitmap Fade()
        {
            var sprite = (Bitmap)Sprite.Clone();
            var h = sprite.Height;
            var w = sprite.Width;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    var color = sprite.GetPixel(x, y);
                    var transparency = color.A;

                    if (transparency - Fading < 0)
                    {
                        transparency = Fading;
                    }

                    sprite.SetPixel(x, y, Color.FromArgb(transparency - Fading, color));
                }
            }

            return sprite;
        }
    }
}
