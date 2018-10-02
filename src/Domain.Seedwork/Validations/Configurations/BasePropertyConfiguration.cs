using Ritter.Infra.Crosscutting;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Validations.Configurations
{
    public abstract class BasePropertyConfiguration<TValidable, TProp>
        where TValidable : class
    {
        protected BasePropertyConfiguration(
            ValidationContext context,
            Expression<Func<TValidable, TProp>> expression)
        {
            Ensure.Argument.NotNull(context, nameof(context));
            Ensure.Argument.NotNull(expression, nameof(expression));

            Context = context;
            Expression = expression;
        }

        public ValidationContext Context { get; protected set; }

        public Expression<Func<TValidable, TProp>> Expression { get; protected set; }
    }
}
