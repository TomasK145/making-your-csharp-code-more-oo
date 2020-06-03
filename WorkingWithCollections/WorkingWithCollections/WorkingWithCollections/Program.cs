using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithCollections
{
    class Program
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                    .Where(p => p.IsAvailable)
                    .WithMinimum(p => p.EstimateCompensation(sqMeters));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
