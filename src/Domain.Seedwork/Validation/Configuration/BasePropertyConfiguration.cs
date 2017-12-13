using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public abstract class BasePropertyConfiguration<TEntity, TProp> where TEntity : class
    {
        protected BasePropertyConfiguration(ValidationContract<TEntity> contract, Expression<Func<TEntity, TProp>> expression)
        {
            Contract = contract ??
                throw new ArgumentNullException(nameof(contract));
            Expression = expression ??
                throw new ArgumentNullException(nameof(expression));
        }

        public ValidationContract<TEntity> Contract { get; protected set; }

        public Expression<Func<TEntity, TProp>> Expression { get; protected set; }
    }
}