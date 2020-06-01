using System;

namespace IteratorDemo
{
    public class Painter : IPainter
    {
        public bool IsAvailable { get; set; }
        public double CompensationPerSqMeter { get; set; }

        public double EstimateCompensation(double sqMeters)
        {
            return CompensationPerSqMeter * sqMeters;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
        {
            throw new NotImplementedException();
        }
    }
}
