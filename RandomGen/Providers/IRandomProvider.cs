namespace RandomGen.Providers
{
    public interface IRandomProvider
    {
        double GetNextDouble();
    }

    public class MirorProvider : IRandomProvider
    {
        private readonly IRandomProvider _provider;
        private readonly int _copies;
        private int counter;
        private double valueToGive;

        public MirorProvider(IRandomProvider provider, int copies)
        {
            _provider = provider;
            _copies = copies;
            counter = 0;
        }

        public double GetNextDouble()
        {
            if (counter == 0)
            {
                counter = _copies;
                valueToGive = _provider.GetNextDouble();
            }

            counter--;
            return valueToGive;
        }
    }
}