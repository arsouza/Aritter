using System;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class CustomRule<TValidable> : ValidationRule<TValidable> where TValidable : class, IValidable
    {
        private readonly Func<TValidable, bool> validateFunc;

        public CustomRule(Func<TValidable, bool> validateFunc) : this(validateFunc, null) { }

        public CustomRule(Func<TValidable, bool> validateFunc, string message) : base(message)
        {
            this.validateFunc = validateFunc ??
                throw new ArgumentNullException(nameof(validateFunc));;
        }

        public override bool Validate(TValidable entity)
        {
            return validateFunc(entity);
        }
    }
}