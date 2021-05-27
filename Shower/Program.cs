using System;
using System.Collections.Generic;
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

            IRandomSystem systemRaw = new RandomSystem(new LinearProvider(new TRandom(0), -10, 10));
            IRandomSystem systemBrownian = new RandomSystem(new LinearProvider(new TRandom(0), -10, 10),
                new List<IRandomFilter>
                {
                    new BrownianFilter()
                });
            IRandomSystem systemBrownianAverage = new RandomSystem(new LinearProvider(new TRandom(0), -10, 10), 
                new List<IRandomFilter>
                {
                    new BrownianFilter(),
                    new SimpleMovingAverageFilter(3)
                });

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