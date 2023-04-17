namespace Project
{
    public class ParticleGenerator
    {
        public Point3D Coordinates { get; set; }
        public Image Sprite { get; set; }
        public Point3D MaxVelocity { get; set; }
        public Point3D MinAcceleration { get; set; }
        public byte MaxFading { get; set; }

        public ParticleGenerator(
            Point3D coordinates,
            Image particleSprite,
            Point3D maxVelocity,
            Point3D minAcceleration,
            byte maxFading = 20
            )
        {
            Coordinates = coordinates;
            Sprite = particleSprite;
            MaxVelocity = maxVelocity;
            MinAcceleration = minAcceleration;
            MaxFading = maxFading;
        }

        public List<Particle> Generate(int amount)
        {
            if (amount < 0)
            {
                throw new IndexOutOfRangeException();
            }

            List<Particle> res = new List<Particle>();

            for (uint i = 0; i < amount; i++)
            {
                res.Add(RandomParticle);
            }

            return res;
        }

        public Particle RandomParticle
        {
            get
            {
                Random rnd = new Random();

                var maxVelocity = MaxVelocity.Clone;
                var minAcceleration = MinAcceleration.Clone;

                return new Particle(
                    Coordinates.Clone, (Image)Sprite.Clone(),
                    new Point3D(
                        rnd.NextSingle() * maxVelocity.X * (rnd.Next(2) == 0 ? 1 : -1),
                        rnd.NextSingle() * maxVelocity.Y,
                        rnd.NextSingle() * maxVelocity.Z * (rnd.Next(2) == 0 ? 1 : -1)
                    ),
                    new Point3D(
                        rnd.NextSingle() * -minAcceleration.X * (rnd.Next(2) == 0 ? 1 : -1),
                        rnd.NextSingle() * -minAcceleration.Y,
                        rnd.NextSingle() * -minAcceleration.Z * (rnd.Next(2) == 0 ? 1 : -1)
                    ),
                    (byte)rnd.Next(MaxFading)
                );
            }
        }
    }
}
