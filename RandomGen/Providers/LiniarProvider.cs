using Troschuetz.Random;

namespace RandomGen.Providers
{
    public class LiniarProvider : IRandomProvider
    {
        
        private readonly TRandom _generator;
        private readonly double _minValue;
        private readonly double _maxValue;

        public LiniarProvider(TRandom generator, double minValue, double maxValue)
        {
            _generator = generator;
            _minValue = minValue;
            _maxValue = maxValue;
        }
        public double GetNextDouble()
        {
            return _generator.NextDouble(_minValue, _maxValue);
        }
    }
}