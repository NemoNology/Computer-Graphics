using System.Numerics;

namespace Project
{
    public class ParticleSystem
    {
        private List<Particle> _particles;
        private ParticleGenerator _particleGenerator;
        private int _particlesAmount;

        public Vector3 Coordinates { get; set; }
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
            Vector3 coordinates,
            Vector3 maxVelocity,
            Vector3 minAcceleration,
            int particlesAmount = 25,
            byte maxFading = 20
        )
        {
            Coordinates = coordinates;
            ParticlesAmount = particlesAmount;

            _particleGenerator = new ParticleGenerator(
                coordinates,
                particleSprite,
                maxVelocity,
                minAcceleration,
                maxFading
            );

            _particles = _particleGenerator.Generate(particlesAmount);
        }

        public void MoveAll()
        {
            Parallel.For(0, _particlesAmount, MoveOne);
        }

        public void MoveOne(int index)
        {
            if (index >= _particlesAmount)
            {
                throw new IndexOutOfRangeException();
            }

            if (_particles[index].Move())
            {
                _particles[index] = _particleGenerator.RandomParticle;
            }
        }
    }
}
