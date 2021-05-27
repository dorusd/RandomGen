namespace RandomGen.Providers
{
    public interface IRandomProvider
    {
        double GetNextDouble();
    }

    public class MirrorProvider : IRandomProvider
    {
        private readonly IRandomProvider _provider;
        private readonly int _copies;
        private int _counter;
        private double _valueToGive;

        public MirrorProvider(IRandomProvider provider, int copies)
        {
            _provider = provider;
            _copies = copies;
            _counter = 0;
        }

        public double GetNextDouble()
        {
            if (_counter == 0)
            {
                _counter = _copies;
                _valueToGive = _provider.GetNextDouble();
            }

            _counter--;
            return _valueToGive;
        }
    }
}