using System;
using System.Threading.Tasks;

namespace System.Runtime.CompilerServices
{
    public class IsExternalInit{}
}

namespace Authorization.Providers
{
    public interface IAuthDataProvider<T, in TContext>
    {
        Task<T> GetData(TContext context);
    }

    class RolesDataProvider : IAuthDataProvider<string[], UserId>
    {
        public Task<string[]> GetData(UserId context)
        {
            throw new NotImplementedException();
        }
    }

    class PermissionsDataProvider : IAuthDataProvider<string[], UserId>
    {
        public Task<string[]> GetData(UserId context)
        {
            throw new NotImplementedException();
        }
    }

    record UserId(Guid Id);
}