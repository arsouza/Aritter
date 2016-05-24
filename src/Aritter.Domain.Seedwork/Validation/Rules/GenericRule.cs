using Aritter.Infras.Crosscutting.Exceptions;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public abstract class GenericRule<T, TProp> : Rule<T>
    {
        protected Func<T, TProp> provider;

        public GenericRule(Func<T, TProp> provider)
        {
            ThrowHelper.ThrowArgumentNullException(provider, nameof(provider));
            this.provider = provider;
        }

        public GenericRule(Expression<Func<T, TProp>> expression)
            : this(expression.Compile())
        {
        }
    }
}
