using System.Threading.Tasks;

namespace Authorization.Checkers
{
    public interface IRuleChecker
    {
        Task Check();
    }
}