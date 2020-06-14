using System;
using System.Collections.Generic;
using System.Linq;

namespace NullObjects.Common
{
    static class EnumerableExtensions
    {
        public static void Do<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            // ToList() call requieres O(n) memory
            //sequence.ToList().ForEach(action);
            
            // sequence itselt might require O(1) only
            foreach (T obj in sequence)
                action(obj);
        }
    }
}
