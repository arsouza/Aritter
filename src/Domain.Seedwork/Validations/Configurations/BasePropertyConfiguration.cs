using Ritter.Infra.Crosscutting;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Validations.Configurations
{
    public abstract class BasePropertyConfiguration<TValidable, TProp> where TValidable : class
    {
        protected BasePropertyConfiguration(ValidationContract<TValidable> contract, Expression<Func<TValidable, TProp>> expression)
        {
            Ensure.Argument.NotNull(contract, nameof(contract));
            Ensure.Argument.NotNull(expression, nameof(expression));

            Contract = contract;
            Expression = expression;
        }

        public ValidationContract<TValidable> Contract { get; protected set; }

        public Expression<Func<TValidable, TProp>> Expression { get; protected set; }
    }
}
