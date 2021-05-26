
using Troschuetz.Random;

namespace RandomGen.Providers
{
    public class RandomProvider : IRandomProvider
    {
        private readonly IGenerator _generator;

        public RandomProvider(IGenerator generator)
        {
            _generator = generator;
        }

        public double GetNextDouble()
        {
            return _generator.NextDouble();
        }
    }
}