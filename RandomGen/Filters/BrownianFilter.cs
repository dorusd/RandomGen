namespace RandomGen.Filters
{
    public class BrownianFilter : IRandomFilter
    {
        private readonly IRandomState _state;

        public BrownianFilter()
        {
            _state = new RandomState(1);
        }

        public double FilterValue(double nextInput)
        {
            double nextValue = _state.GetLastValue() + nextInput;
            _state.SetNextValue(nextValue);
            return nextValue;
        }
    }
}