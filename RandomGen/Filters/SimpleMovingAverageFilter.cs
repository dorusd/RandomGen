using System.Linq;

namespace RandomGen.Filters
{
    public class SimpleMovingAverageFilter : IRandomFilter
    {
        private readonly IRandomState _state;
        private readonly int _averageSize;

        public SimpleMovingAverageFilter(int averageSize)
        {
            _averageSize = averageSize;
            _state = new RandomState(averageSize);
        }

        public double FilterValue(double nextInput)
        {
            _state.SetNextValue(nextInput);
            double nextValue = _state.GetPreviousValues(_averageSize).Average();
            return nextValue;
        }
    }
}