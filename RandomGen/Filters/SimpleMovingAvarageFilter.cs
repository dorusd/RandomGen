using System.Linq;

namespace RandomGen.Filters
{
    public class SimpleMovingAvarageFilter:IRandomFilter
    {
        private readonly IRandomState _state;
        private readonly int _avargaSize;

        public SimpleMovingAvarageFilter(int avarageSize)
        {
            _avargaSize = avarageSize;
            _state = new RandomState(avarageSize);
        }

        public double FilterValue(double nextInput)
        {
            _state.SetNextValue(nextInput);
            double nextValue = _state.GetLastValues(_avargaSize).Average();
            return nextValue;
        }
    }
}