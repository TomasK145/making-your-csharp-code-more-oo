using System.Collections.Generic;

namespace WorkingWithCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];

            IPainter painter = CompositePainterFactories.CreateGroup(painters);
        }
    }
}
