using System;
using System.Collections.Generic;
using RandomGen.Filters;
using RandomGen.Providers;

namespace RandomGen
{
    public class RandomSystem : IRandomSystem
    {
        private readonly IRandomProvider _provider;
        private readonly IEnumerable<IRandomFilter> _filters;

        private RandomSystem() {}

        public RandomSystem(IRandomProvider provider, IEnumerable<IRandomFilter> filters = null)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _filters = filters != null ? new List<IRandomFilter>(filters) : new List<IRandomFilter>();
        }

        public double NextValue()
        {
            double result = _provider.GetNextDouble();
            foreach (var filter in _filters)
            {
                result = filter.FilterValue(result);
            }

            return result;
        }
    }
}