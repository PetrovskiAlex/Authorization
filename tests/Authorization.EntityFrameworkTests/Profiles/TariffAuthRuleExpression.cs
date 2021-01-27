using System;
using System.Linq.Expressions;
using Authorization.EntityFramework;
using Authorization.Rules;

namespace Authorization.Tests.Profiles
{
    public class TariffAuthRuleExpression : IRuleExpression<Tariff, AuthContext>
    {
        public Expression<Func<Tariff, bool>> Apply(AuthContext context)
        {
            Expression<Func<Tariff, bool>> predicate = t =>
                (context.CompanyId.HasValue && t.CompanyId == context.CompanyId) || t.UserId == context.UserId;

            return predicate;
        }
    }
}