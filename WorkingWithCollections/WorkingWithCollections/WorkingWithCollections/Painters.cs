using System.Collections.Generic;
using System.Linq;

namespace WorkingWithCollections
{
    //Data structure places in own class
    class Painters
    {
        private IEnumerable<IPainter> ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            this.ContainedPainters = painters.ToList();
        }

        //GetAvailable() --> is closed under the set of all Painters objects
        //it is mapping one Painters object into another Painters object
        public Painters GetAvailable() =>
            new Painters(this.ContainedPainters.Where(p => p.IsAvailable));

        public IPainter GetCheapestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(p => p.EstimateCompensation(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            this.ContainedPainters.WithMinimum(p => p.EstimateTimeToPaint(sqMeters));
    }
}
