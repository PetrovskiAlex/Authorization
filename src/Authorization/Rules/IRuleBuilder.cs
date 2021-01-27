using System;
using System.Linq.Expressions;

namespace Authorization.Rules
{
    public interface IRuleBuilder<T>
    {
        IRuleBuilder<T> HaveRule(IRule<T> rule);
        IRuleBuilder<T> Expression<TContext>(Expression<Func<T, TContext, bool>> expression);
    }
}