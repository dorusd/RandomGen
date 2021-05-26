using System;
using RandomGen;
using RandomGen.Filters;
using RandomGen.Providers;
using Troschuetz.Random;

namespace Shower
{
    internal class Program
    {
        public Program()
        {
        }

        private static void Main(string[] args)
        {
            const int n = 50;
            TRandom trandom = new TRandom();
            IRandomProvider provider = new MirorProvider(new LiniarProvider(trandom, -10, 10), 3);
            IRandomProviderBuilder builderRaw = new RandomSystmBuilder();
            IRandomProviderBuilder builderBrownien = new RandomSystmBuilder();
            IRandomProviderBuilder builderAvarage = new RandomSystmBuilder();
            IRandomSystem systemRaw = builderRaw.AddProvider(provider).Build();
            IRandomSystem systemBrownien = builderBrownien.AddProvider(provider).AddFilter(new BrownienFilter()).Build();
            IRandomSystem systemBrownienAvarage = builderAvarage.AddProvider(provider)
                .AddFilter(new BrownienFilter())
                .AddFilter(new SimpleMovingAvarageFilter(3)).Build();
            for (int i = 0; i < n; i++)
            {
                var raw = systemRaw.NextValue();
                var brownien = systemBrownien.NextValue();
                var brownienAvarage = systemBrownienAvarage.NextValue();
                Console.WriteLine($"{raw}, {brownien}, {brownienAvarage}");
            }
        }
    }
}