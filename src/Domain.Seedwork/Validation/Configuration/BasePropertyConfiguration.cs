using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public abstract class BasePropertyConfiguration<TValidable, TProp> where TValidable : class
    {
        protected BasePropertyConfiguration(ValidationContract<TValidable> contract, Expression<Func<TValidable, TProp>> expression)
        {
            Contract = contract ??
                throw new ArgumentNullException(nameof(contract));
            Expression = expression ??
                throw new ArgumentNullException(nameof(expression));
        }

        public ValidationContract<TValidable> Contract { get; protected set; }

        public Expression<Func<TValidable, TProp>> Expression { get; protected set; }
    }
}