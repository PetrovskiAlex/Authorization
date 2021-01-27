using System;
using System.Linq.Expressions;

namespace Authorization.Rules
{
    public interface IRuleExpression<T, in TContext>
    {
        Expression<Func<T, bool>> Apply(TContext context);
    }
}