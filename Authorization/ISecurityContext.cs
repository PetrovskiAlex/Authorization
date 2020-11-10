using System.Collections.Generic;
using System.Linq;

namespace Authorization
{
    public interface ISecurityContext
    {
        T Get<T, TContext>(TContext context) where T : class;
        IEnumerable<T> GetEnumerable<T, TContext>(IEnumerable<T> source, TContext context) where T : class;
        IQueryable<T> GetQueryable<T, TContext>(TContext context) where T : class;
        T Insert<T, TContext>(T t, TContext context);
        T Update<T, TContext>(T t, TContext context);
    }
}