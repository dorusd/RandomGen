namespace RandomGen.Filters
{
    public class BrownienFilter:IRandomFilter
    {
        private readonly IRandomState _state;

        public BrownienFilter()
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