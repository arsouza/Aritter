using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public abstract class BasePropertyConfiguration<TEntity, TProp> where TEntity : class
    {
        protected BasePropertyConfiguration(ValidationContext<TEntity> context, Expression<Func<TEntity, TProp>> expression)
        {
            Context = context ??
                throw new ArgumentNullException(nameof(context));
            Expression = expression ??
                throw new ArgumentNullException(nameof(expression));
        }

        public ValidationContext<TEntity> Context { get; protected set; }

        public Expression<Func<TEntity, TProp>> Expression { get; protected set; }
    }
}