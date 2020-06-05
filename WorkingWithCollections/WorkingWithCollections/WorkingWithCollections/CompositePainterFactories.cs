using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithCollections
{
    static class CompositePainterFactories
    {
        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters));

        public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetFastestOne(sqMeters));

        public static IPainter CreateGroup(IEnumerable<ProportionalPainter> painters) =>
            new CompositePainter<ProportionalPainter>(painters, (sqMeters, sequence) =>
            {
                TimeSpan time = TimeSpan.FromHours(
                    1 /
                    sequence
                        .Where(p => p.IsAvailable)
                        .Select(p => 1 / p.EstimateTimeToPaint(sqMeters).TotalHours)
                        .Sum() // velocity of all painters
                        );

                double cost = //celkova suma
                   sequence
                       .Where(p => p.IsAvailable)
                       .Select(p =>
                           p.EstimateCompensation(sqMeters) /
                           p.EstimateTimeToPaint(sqMeters).TotalHours *
                           time.TotalHours)
                       .Sum();
                return new ProportionalPainter()
                {
                    TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                    DollarsPerHour = cost / time.TotalHours
                };
            });
    }
}
