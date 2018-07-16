using System.Collections.Generic;
using System.Linq;

namespace LinqWut
{
    public static class LinqWutExtensions
    {
        public static TEntity SingleWithContext<TEntity>(this IEnumerable<TEntity> value)
        {
            return value.Single();
        }
    }
}
