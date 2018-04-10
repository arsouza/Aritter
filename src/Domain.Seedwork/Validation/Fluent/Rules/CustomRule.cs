using Ritter.Domain.Seedwork.Validation.Fluent;
using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class CustomRule<TValidable> : ValidationRule<TValidable> where TValidable : class, IValidable<TValidable>
    {
        private readonly Func<TValidable, bool> validateFunc;

        public CustomRule(Func<TValidable, bool> validateFunc) : this(validateFunc, null) { }

        public CustomRule(Func<TValidable, bool> validateFunc, string message) : base(message)
        {
            Ensure.Argument.NotNull(validateFunc, nameof(validateFunc));
            this.validateFunc = validateFunc;
        }

        public override bool Validate(TValidable entity)
        {
            return validateFunc(entity);
        }
    }
}
