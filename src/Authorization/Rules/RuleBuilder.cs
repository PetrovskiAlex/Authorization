using System;
using System.Linq.Expressions;

namespace Authorization.Rules
{
    public class RuleBuilder<T> : IRuleBuilder<T>
    {
        public IRuleBuilder<T> HaveRule(IRule<T> rule)
        {
            throw new NotImplementedException();
        }

        public IRuleBuilder<T> Expression<TContext>(Expression<Func<T, TContext, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}