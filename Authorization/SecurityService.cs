using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization
{
    public abstract class SecurityService : ISecurityService
    {
        public Task<T> Get<T, TContext>(TContext context) where T : class where TContext : class
        {
            return CheckPermissionAndExecute(GetEntity<T, TContext>, context);
        }

        protected abstract Task<T> GetEntity<T, TContext>(TContext context) where T : class where TContext : class;
        

        public Task<IEnumerable<T>> GetEnumerable<T, TContext>(IEnumerable<T> source, TContext context) where T : class where TContext : class
        {
            return CheckPermissionAndExecute(GetEntitiesAsEnumerable<T, TContext>, context);
        }
        protected abstract Task<IEnumerable<T>> GetEntitiesAsEnumerable<T, TContext>(TContext context) where T : class where TContext : class;
        

        public Task<IQueryable<T>> GetQueryable<T, TContext>(TContext context) where T : class where TContext : class
        {
            return CheckPermissionAndExecute(GetEntitiesAsQueryable<T, TContext>, context);
        }
        protected abstract Task<IQueryable<T>> GetEntitiesAsQueryable<T, TContext>(TContext context) where T : class where TContext : class;
        

        public Task<T> Insert<T, TContext>(T t, TContext context) where T : class where TContext : class
        {
            return CheckPermissionAndExecute(InsertEntity, t, context);
        }

        protected abstract Task<T> InsertEntity<T, TContext>(T t, TContext data) where T : class where TContext : class;
        

        public Task<T> Update<T, TContext>(T t, TContext context) where T : class where TContext : class
        {
            return CheckPermissionAndExecute(UpdateEntity, t, context);
        }

        protected abstract Task<T> UpdateEntity<T, TContext>(T t, TContext data) where T : class where TContext : class;
        

        public Task<T> Delete<T, TContext>(T t, TContext context) where T : class where TContext : class
        {
            return CheckPermissionAndExecute(DeleteEntity, t, context);
        }

        protected abstract Task<T> DeleteEntity<T, TContext>(T t, TContext data) where T : class where TContext : class;


        private async Task<T> CheckPermissionAndExecute<T, TContext>(Func<TContext, Task<T>> action, TContext context) where TContext : class
        {
            //check rules

            return await action(context);
        }

        private async Task<T> CheckPermissionAndExecute<T, TContext>(Func<T, TContext, Task<T>> action, T t, TContext context) where TContext : class
        {
            //check rules

            return await action(t, context);
        }
    }
}