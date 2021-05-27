using System;
using System.Collections.Generic;
using RandomGen.Filters;
using RandomGen.Providers;

namespace RandomGen
{
    public class RandomSystem : IRandomSystem
    {
        private readonly IRandomProvider _provider;
        private readonly List<IRandomFilter> _filters;

        public RandomSystem(IRandomProvider provider, List<IRandomFilter> filters = null)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _filters = filters ?? new List<IRandomFilter>();
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