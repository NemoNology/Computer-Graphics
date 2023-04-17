namespace Project
{
    public class ParticleSystem
    {
        private List<Particle> _particles;
        private ParticleGenerator _particleGenerator;
        private int _particlesAmount;

        public List<Particle> Particles => _particles;

        public Point3D Coordinates { get; set; }
        public int ParticlesAmount
        {
            get => _particlesAmount;
            set
            {
                _particlesAmount = value;
                _particles = _particleGenerator.Generate(value);
            }
        }

        public ParticleSystem(
            Image particleSprite,
            Point3D coordinates,
            Point3D maxVelocity,
            Point3D minAcceleration,
            int particlesAmount = 25,
            byte maxFading = 20
        )
        {
            _particleGenerator = new ParticleGenerator(
                coordinates,
                particleSprite,
                maxVelocity,
                minAcceleration,
                maxFading
            );

            Coordinates = coordinates;
            ParticlesAmount = particlesAmount;

            _particles = _particleGenerator.Generate(particlesAmount);
        }

        public void MoveAll()
        {
            Parallel.ForEach(_particles, particle =>
            {
                if (particle.Move())
                {
                    particle = _particleGenerator.RandomParticle;
                }
            });
        }
    }
}
