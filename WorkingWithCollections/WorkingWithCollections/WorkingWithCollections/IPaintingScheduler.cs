﻿using System.Collections.Generic;

namespace WorkingWithCollections
{
    public interface IPaintingScheduler<TPainter> where TPainter : IPainter
    {
        IEnumerable<PaintingTask<TPainter>> Schedule(double sqMeters, IEnumerable<TPainter> painters);
    }
}
