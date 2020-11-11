using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Authorization.EntityFramework
{
    public class EfSecurityService<TDbContext> : SecurityService where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;

        public EfSecurityService(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override Task<T> GetEntity<T, TContext>(TContext context) where T : class
        {
            var entity = _dbContext.Set<T>()
                .Where(t => true)
                .FirstOrDefaultAsync();

            return entity;
        }

        protected override Task<IEnumerable<T>> GetEntitiesAsEnumerable<T, TContext>(TContext context) where T : class
        {
            var result = _dbContext.Set<T>()
                .Where(t => true)
                .AsEnumerable();

            return Task.FromResult(result);
        }
        
        protected override Task<IQueryable<T>> GetEntitiesAsQueryable<T, TContext>(TContext context) where T : class
        {
            var query = _dbContext.Set<T>()
                .Where(t => true);

            return Task.FromResult(query);
        }

        protected override async Task<T> InsertEntity<T, TContext>(T t, TContext data) where T : class
        {
            var entityEntry = await _dbContext.AddAsync(t);
            await _dbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        protected override async Task<T> UpdateEntity<T, TContext>(T t, TContext data) where T : class
        {
            var entityEntry = _dbContext.Update(t);
            await _dbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        protected override async Task<T> DeleteEntity<T, TContext>(T t, TContext data) where T : class
        {
            var entityEntry = _dbContext.Remove(t);
            await _dbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        /*public T Get<T, TContext>(TContext context) where T : class
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
        }*/
    }
}