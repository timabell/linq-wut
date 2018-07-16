using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqWut
{
    public static class LinqWutExtensions
    {
        public static TEntity SingleWithContext<TEntity>(this IEnumerable<TEntity> value)
        {
            var results = value.ToList();
            var resultsCount = results.Count;
            if (resultsCount == 0)
            {
                throw new InvalidOperationException($"Expected 1 {typeof(TEntity)} but got 0");
            }
            if (resultsCount > 1)
            {
                throw new InvalidOperationException($"Expected 1 {typeof(TEntity)} but got {resultsCount}");
            }
            return results[0];
        }
    }
}
