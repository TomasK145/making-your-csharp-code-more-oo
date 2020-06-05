using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithCollections
{
    class CompositePainter<TPainter> : IPainter
        where TPainter : IPainter
    {
        private IEnumerable<TPainter> Painters { get; }

        private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }

        public bool IsAvailable => this.Painters.Any(p => p.IsAvailable);

        public CompositePainter(IEnumerable<TPainter> painters,
            Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            Painters = painters;
            Reduce = reduce;
        }

        //sluzi na reduce kolekcie painters na jedneho IPainter
        //reduce metoda funguje korektne len s proportional paintermi
        /*private IPainter Reduce(double sqMeters)
        {
            TimeSpan time = TimeSpan.FromHours(
                1 /
                this.Painters
                    .Where(p => p.IsAvailable)
                    .Select(p => 1 / p.EstimateTimeToPaint(sqMeters).TotalHours)
                    .Sum() // velocity of all painters
                    );

            double cost = //celkova suma
               this.Painters
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
        }*/

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            this.Reduce(sqMeters, this.Painters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            this.Reduce(sqMeters, this.Painters).EstimateCompensation(sqMeters);
    }
}
