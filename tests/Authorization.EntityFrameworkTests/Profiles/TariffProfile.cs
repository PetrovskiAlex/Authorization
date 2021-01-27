using Authorization.EntityFramework;
using Authorization.Rules;

namespace Authorization.Tests.Profiles
{
    public class TariffProfile : Profile
    {
        private readonly IRuleExpression<Tariff, AuthContext> _rule;
        
        public TariffProfile(IRuleExpression<Tariff, AuthContext> rule)
        {
            _rule = rule;
        }

        public bool Apply(Tariff tariff, AuthContext context)
        {
            var func = _rule.Apply(context).Compile();
            return func(tariff);
        }
    }
}