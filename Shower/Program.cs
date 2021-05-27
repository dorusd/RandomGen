using System;
using RandomGen;
using RandomGen.Filters;
using RandomGen.Providers;
using Troschuetz.Random;

namespace Shower
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int n = 50;
            TRandom tRandom = new TRandom();
            IRandomProvider provider = new MirrorProvider(new LinearProvider(tRandom, -10, 10), 3);
            IRandomProviderBuilder builderRaw = new RandomSystemBuilder();
            IRandomProviderBuilder builderBrownian = new RandomSystemBuilder();
            IRandomProviderBuilder builderAverage = new RandomSystemBuilder();
            IRandomSystem systemRaw = builderRaw.AddProvider(provider).Build();
            IRandomSystem systemBrownian = builderBrownian.AddProvider(provider).AddFilter(new BrownianFilter()).Build();
            IRandomSystem systemBrownianAverage = builderAverage.AddProvider(provider)
                .AddFilter(new BrownianFilter())
                .AddFilter(new SimpleMovingAverageFilter(3)).Build();

            for (int i = 0; i < n; i++)
            {
                var raw = systemRaw.NextValue();
                var brownian = systemBrownian.NextValue();
                var brownianAverage = systemBrownianAverage.NextValue();
                Console.WriteLine($"{raw}, {brownian}, {brownianAverage}");
            }
        }
    }
}