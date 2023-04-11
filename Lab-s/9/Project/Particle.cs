using System.Numerics;

namespace Project
{
    internal class Particle
    {
        public Vector3 Coordinates { get; set; }
        public Image Sprite { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; set; }
        public byte Fading { get; set; }

        public Particle(
            Vector3 coordinates,
            Image sprite,
            Vector3 velocity,
            Vector3 acceleration,
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

            Velocity = new Vector3(0, Velocity.Y, Velocity.Z);
            Acceleration = new Vector3(0, Acceleration.Y, Acceleration.Z);

            if (Velocity.Y < 0)
            {
                Velocity = new Vector3(Velocity.X, 0, Velocity.Z);
                Acceleration = new Vector3(Acceleration.X, 0, Acceleration.Z);
            }

            Velocity = new Vector3(Velocity.X, Velocity.Y, 0);
            Acceleration = new Vector3(Acceleration.X, Acceleration.Y, 0);

            Sprite = Fade().Result;

            return IsTransparent;
        }

        private bool IsTransparent
        {
            get
            {
                var sprite = (Bitmap)Sprite;
                var h = sprite.Height;
                var w = sprite.Width;

                Task<bool> res = Task.Run(() =>
                {
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
                });

                return res.Result;
            }
        }

        private async Task<Bitmap> Fade()
        {
            var sprite = (Bitmap)Sprite;
            var h = sprite.Height;
            var w = sprite.Width;

            Task res = Task.Run(() =>
            {
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
            });

            await res;

            return sprite;
        }
    }
}
