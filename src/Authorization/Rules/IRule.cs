using System.Threading.Tasks;

namespace Authorization.Rules
{
    public interface IRule<in T>
    {
        void Check(T actualValue);
    }

    public interface IRule
    {
        Task Check();
    }
}