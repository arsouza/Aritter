using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Configurations
{
    public abstract class BasePropertyConfiguration<TValidable, TProp>
        where TValidable : class
    {
        protected BasePropertyConfiguration(
            ValidationContext context,
            Expression<Func<TValidable, TProp>> expression)
        {
            Ensure.ArgumentNotNull(context, nameof(context));
            Ensure.ArgumentNotNull(expression, nameof(expression));

            Context = context;
            Expression = expression;
        }

        public ValidationContext Context { get; protected set; }

        public Expression<Func<TValidable, TProp>> Expression { get; protected set; }
    }
}
