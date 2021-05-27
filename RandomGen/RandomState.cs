using System;
using System.Linq;

namespace RandomGen
{
    public class RandomState : IRandomState
    {
        public RandomState(int memorySize)
        {
            _memorySize = memorySize;
            _memory = new double[memorySize];
            _memoryPointer = 0;
        }

        private readonly int _memorySize;
        private readonly double[] _memory;
        private int _memoryPointer;

        public double GetLastValue()
        {
            return GetPreviousValues(1).First();
        }


        public void SetNextValue(double nextInput)
        {
            _memoryPointer = (_memoryPointer) % _memorySize;
            _memory[_memoryPointer] = nextInput;
        }

        public double[] GetPreviousValues(int amount)
        {
            if (amount > _memorySize)
            {
                throw new ArgumentOutOfRangeException();
            }

            int start = _memoryPointer - amount;
            double[] doubles;
            if (start < 0)
            {
                int fromEnd = _memorySize + start;
                int fromStart = amount + start;
                doubles = _memory.Skip(fromEnd).Concat(_memory.Take(fromStart)).ToArray();
                return doubles;
            }

            doubles = _memory.Skip(start).Take(amount).ToArray();

            return doubles;
        }
    }
}