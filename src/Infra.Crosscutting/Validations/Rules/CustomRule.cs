using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class CustomRule<TValidable, TProp> : PropertyRule<TValidable, TProp> where TValidable : class
    {
        private readonly Func<TValidable, bool> validateFunc;

        public CustomRule(Expression<Func<TValidable, TProp>> expression, Func<TValidable, bool> validateFunc) : this(expression, validateFunc, null) { }

        public CustomRule(Expression<Func<TValidable, TProp>> expression, Func<TValidable, bool> validateFunc, string message) : base(expression, message)
        {
            Ensure.Argument.NotNull(validateFunc, nameof(validateFunc));
            this.validateFunc = validateFunc;
        }

        public override bool IsValid(TValidable entity)
        {
            return validateFunc(entity);
        }
    }
}
