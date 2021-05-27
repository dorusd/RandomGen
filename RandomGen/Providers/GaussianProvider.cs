using Troschuetz.Random;

namespace RandomGen.Providers
{
    public class GaussianProvider : IRandomProvider
    {
        private readonly TRandom _generator;
        private readonly double _mu;
        private readonly double _sigma;

        public GaussianProvider(TRandom generator, double mu, double sigma)
        {
            _generator = generator;
            _mu = mu;
            _sigma = sigma;
        }
        public double GetNextDouble()
        {
            return _generator.Normal(_mu, _sigma);
        }
    }
}