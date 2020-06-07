using System.Collections.Generic;

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

        public static IPainter CombineProportional(IEnumerable<ProportionalPainter> painters) =>
            // first argument is sequence of painters to combine + strategy how to combine painters
            // painters --> what to combine
            // ProportionalPaintingScheduler --> how to combines
            new CombiningPainter<ProportionalPainter>(painters, new ProportionalPaintingScheduler());
    }
}
