using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithCollections
{
    class CombiningPainter<TPainter> : CompositePainter<TPainter>
        where TPainter : IPainter
    {
        //private Func<double, IEnumerable<TPainter>, IEnumerable<Tuple<TPainter, double>>> ScheduleWork { get; }
        private IPaintingScheduler<TPainter> Scheduler ;

        public CombiningPainter(IEnumerable<TPainter> painters,
            IPaintingScheduler<TPainter> scheduler) : base(painters)
        {
            base.Reduce = this.Combine;
            this.Scheduler = scheduler;
        }

        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            // filter out available painters
            IEnumerable<TPainter> availablePainters = painters.Where(p => p.IsAvailable);

            // schedule work - depends on concrete implementation 
            var schedule = this.Scheduler.Schedule(sqMeters, painters); // Extension point

            // vypocet casu - delegovana praca k Painter objektu
            TimeSpan time = schedule.Max(task => task.Painter.EstimateTimeToPaint(task.SquareMeters));

            // vypocet ceny - delegovana praca k Painter objektu
            double cost = schedule.Sum(task => task.Painter.EstimateCompensation(task.SquareMeters));

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }

        // time estimation is now the extension point of this algorithm 
        //public Func<double, IEnumerable<ProportionalPainter>, TimeSpan> EstimateTime { get; set; }
    }
}
