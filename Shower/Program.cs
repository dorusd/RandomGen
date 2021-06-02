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
            var seed = new Random().Next();

            IRandomSystem systemRaw = new RandomSystem(
                new LinearProvider(new TRandom(seed), -10, 10));

            IRandomSystem systemBrownian = new RandomSystem(
                new LinearProvider(new TRandom(seed), -10, 10),
                new BrownianFilter());

            IRandomSystem systemBrownianAverage = new RandomSystem(
                new LinearProvider(new TRandom(seed), -10, 10),
                new BrownianFilter(),
                new SimpleMovingAverageFilter(3));

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