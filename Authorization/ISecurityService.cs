using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization
{
    public interface ISecurityService
    {
        Task<T> Get<T, TContext>(TContext context) where T : class where TContext : class;
        Task<IEnumerable<T>> GetEnumerable<T, TContext>(IEnumerable<T> source, TContext context) where T : class where TContext : class;
        Task<IQueryable<T>> GetQueryable<T, TContext>(TContext context) where T : class where TContext : class;
        Task<T> Insert<T, TContext>(T t, TContext context) where T : class where TContext : class;
        Task<T> Update<T, TContext>(T t, TContext context) where T : class where TContext : class;
        Task<T> Delete<T, TContext>(T t, TContext context) where T : class where TContext : class;
    }
}