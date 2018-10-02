using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public abstract class PropertyRule<TValidable, TProp> : ValidationRule<TValidable> where TValidable : class
    {
        protected Expression<Func<TValidable, TProp>> Expression { get; private set; }

        protected PropertyRule(Expression<Func<TValidable, TProp>> expression) : this(expression, null) { }

        protected PropertyRule(Expression<Func<TValidable, TProp>> expression, string message) : base(expression.GetPropertyName(), message)
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            Expression = expression;
        }

        protected TProp Compile(TValidable entity)
        {
            return Expression.Compile()(entity);
        }
    }
}
