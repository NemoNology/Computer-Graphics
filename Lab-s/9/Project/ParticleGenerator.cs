using System.Numerics;

namespace Project
{
    internal class ParticleGenerator
    {
        public Vector3 Coordinates { get; set; }
        public Image Sprite { get; set; }
        public Vector3 MaxVelocity { get; set; }
        public Vector3 MinAcceleration { get; set; }
        public byte MaxFading { get; set; }

        public ParticleGenerator(
            Vector3 coordinates,
            Image particleSprite,
            Vector3 maxVelocity,
            Vector3 minAcceleration,
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

                return new Particle(
                    Coordinates, Sprite, 
                    new Vector3(
                        rnd.NextSingle() * MaxVelocity.X, 
                        rnd.NextSingle() * MaxVelocity.Y, 
                        rnd.NextSingle() * MaxVelocity.Z 
                    ),
                    new Vector3(
                        rnd.NextSingle() * MinAcceleration.X, 
                        rnd.NextSingle() * MinAcceleration.Y, 
                        rnd.NextSingle() * MinAcceleration.Z 
                    ),
                    (byte)rnd.Next(MaxFading)
                );
            }
        }
    }
}
