using Troschuetz.Random;

namespace RandomGen.Providers
{
    public class DxProvider : IRandomProvider
    {
        private readonly TRandom _generator;
        private readonly int _diceType;
        private readonly int _amount;

        public DxProvider(TRandom generator, int diceType, int amount)
        {
            _generator = generator;
            _diceType = diceType;
            _amount = amount;
        }

        public double GetNextDouble()
        {
            int sum = 0;
            for (int i = 0; i < _amount; i++)
            {
                sum += _generator.Next(1, _diceType);
            }

            return sum;
        }
    }
}