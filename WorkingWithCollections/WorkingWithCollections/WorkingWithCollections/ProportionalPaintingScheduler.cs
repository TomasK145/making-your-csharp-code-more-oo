using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithCollections
{
    public class ProportionalPaintingScheduler : IPaintingScheduler<ProportionalPainter>
    {
        public IEnumerable<PaintingTask<ProportionalPainter>> Schedule(double sqMeters,
            IEnumerable<ProportionalPainter> painters)
        {
            IEnumerable<Tuple<ProportionalPainter, double>> velocities =
                painters
                .Select(p =>
                    Tuple.Create(p, sqMeters / p.EstimateTimeToPaint(sqMeters).TotalHours))
                .ToList();

            double totalVelocity = velocities.Sum(tuple => tuple.Item2);

            IEnumerable<PaintingTask<ProportionalPainter>> schedule =
                velocities
                    .Select(tuple =>
                        new PaintingTask<ProportionalPainter>(
                            tuple.Item1,
                            sqMeters * tuple.Item2 / totalVelocity))
                    .ToList();

            return schedule;
        }
    }
}
