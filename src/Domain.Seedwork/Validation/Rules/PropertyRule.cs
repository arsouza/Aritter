using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public abstract class PropertyRule<TEntity, TProp> : ValidationRule<TEntity>
        where TEntity : class
    {
        protected Expression<Func<TEntity, TProp>> Expression { get; private set; }

        protected PropertyRule(Expression<Func<TEntity, TProp>> expression)
            : this(expression, null)
        {
        }

        protected PropertyRule(Expression<Func<TEntity, TProp>> expression, string message)
            : base(expression.GetPropertyName(), message)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        protected TProp Compile(TEntity entity)
        {
            return Expression.Compile()(entity);
        }
    }
}
