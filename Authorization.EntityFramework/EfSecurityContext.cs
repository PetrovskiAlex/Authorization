using System.Collections.Generic;
using System.Linq;

namespace Authorization.EntityFramework
{
    public class EfSecurityContext<TDbContext> : ISecurityContext where TDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly TDbContext _dbContext;

        public EfSecurityContext(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get<T, TContext>(TContext context) where T : class
        {
            // check role
            // check permission

            var entity = _dbContext.Set<T>()
                .Where(t => true)
                .FirstOrDefault();

            return entity;
        }

        public IEnumerable<T> GetEnumerable<T, TContext>(IEnumerable<T> source, TContext context) where T : class
        {
            // check role
            // check permission

            return source.Where(t => true);
        }

        public IQueryable<T> GetQueryable<T, TContext>(TContext context) where T : class
        {
            // check role
            // check permission

            return _dbContext.Set<T>()
                .Where(t => true);
        }

        public T Insert<T, TContext>(T t, TContext context)
        {
            // check role
            // check permission

            var entityEntry = _dbContext.Add(t);
            _dbContext.SaveChanges();

            return (T) entityEntry.Entity;
        }

        public T Update<T, TContext>(T t, TContext context)
        {
            // check role
            // check permission

            var entityEntry = _dbContext.Update(t);
            _dbContext.SaveChanges();

            return (T) entityEntry.Entity;
        }
    }
}