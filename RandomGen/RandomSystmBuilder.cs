using System.Collections.Generic;
using System.Linq;
using RandomGen.Filters;
using RandomGen.Providers;

namespace RandomGen
{
    public interface IRandomProviderBuilder:IRandomSystemBuilder
    {
        public IRandomFilterBuilder AddProvider(IRandomProvider provider);
    }

    public interface IRandomFilterBuilder:IRandomSystemBuilder
    {
        IRandomFilterBuilder AddFilter(IRandomFilter provider);
    }

    public interface IRandomSystemBuilder
    {
        IRandomSystem Build();
    }

    public interface IRandomSystem
    {
        double NextValue();
    }

    public class RandomSystmBuilder : IRandomProviderBuilder,IRandomFilterBuilder,  IRandomSystem
    {
        private IRandomProvider _provider;
        private readonly List<IRandomFilter> _filters;

        public RandomSystmBuilder()
        {
            _filters = new List<IRandomFilter>();
        }

        public IRandomFilterBuilder AddProvider(IRandomProvider provider)
        {
            _provider = provider;
            return this;
        }

        public IRandomFilterBuilder AddFilter(IRandomFilter filter)
        {
            _filters.Add(filter);
            return this;
        }

        public IRandomSystem Build()
        {
            return this;
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