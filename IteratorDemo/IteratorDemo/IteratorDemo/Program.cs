using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IteratorDemo
{
    class Program
    {
        private static IPainter FindCheapestPainterWithForeach(double sqMeters, IEnumerable<IPainter> painters)
        {
            double bestPrice = 0;
            IPainter cheapest = null;
            foreach (var painter in painters)
            {
                if (painter.IsAvailable)
                {
                    double price = painter.EstimateCompensation(sqMeters);
                    if (cheapest == null || price < bestPrice)
                    {
                        cheapest = painter;
                    }
                }
            }
            return cheapest;
        }

        private static IPainter FindCheapestPainterWithSort(double sqMeters, IEnumerable<IPainter> painters)
        {
            //painters.ThoseAvailable().WithMinimum(painter.EstimateCompensation(sqMeters));
            return painters
                    .Where(p => p.IsAvailable)
                    .OrderBy(p => p.EstimateCompensation(sqMeters))
                    .FirstOrDefault();
            // Bad idea: Sorting --> O(NlogN) running time

            // Better idea: picking O(N) running time
        }

        private static IPainter FindCheapestPainterWithAggregation(double sqMeters, IEnumerable<IPainter> painters)
        {
            //painters.ThoseAvailable().WithMinimum(painter.EstimateCompensation(sqMeters));
            return painters
                    .Where(p => p.IsAvailable)
                    .Aggregate((IPainter)null,(best, cur) =>
                        best == null || best.EstimateCompensation(sqMeters) < cur.EstimateCompensation(sqMeters) ? best : cur);
            // Better idea: picking O(N) running time
        }

        private static IPainter FindCheapestPainterWithAggregationExtension(double sqMeters, IEnumerable<IPainter> painters)
        {
            //painters.ThoseAvailable().WithMinimum(painter.EstimateCompensation(sqMeters));
            return painters
                    .Where(p => p.IsAvailable)
                    .WithMinimum(p => p.EstimateCompensation(sqMeters));
        }


        static void Main(string[] args)
        {
            var painters = GetPainters();

            var sw = new Stopwatch();
            sw.Start();
            var cheapest = FindCheapestPainterWithForeach(13.25, painters);
            sw.Stop();
            Console.WriteLine("FindCheapestPainterWithForeach: " + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            cheapest = FindCheapestPainterWithSort(13.25, painters);
            sw.Stop();
            Console.WriteLine("FindCheapestPainterWithSort: " + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            cheapest = FindCheapestPainterWithAggregation(13.25, painters);
            sw.Stop();
            Console.WriteLine("FindCheapestPainterWithAggregation: " + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            cheapest = FindCheapestPainterWithAggregationExtension(13.25, painters);
            sw.Stop();
            Console.WriteLine("FindCheapestPainterWithAggregationExtension: " + sw.ElapsedMilliseconds + " ms");

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static IEnumerable<IPainter> GetPainters()
        {
            return new List<Painter>
            {
                new Painter { IsAvailable = true, CompensationPerSqMeter = 10.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 12.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 11.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 8.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 13.45 },
                new Painter { IsAvailable = false, CompensationPerSqMeter = 10.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 8.25 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 90.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 9.45 },
                new Painter { IsAvailable = false, CompensationPerSqMeter = 11.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 11.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 12.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 13.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 14.45 },
                new Painter { IsAvailable = false, CompensationPerSqMeter = 15.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 6.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 9.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 10.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 10.45 },
                new Painter { IsAvailable = true, CompensationPerSqMeter = 10.45 },
            };
        }
    }
}
