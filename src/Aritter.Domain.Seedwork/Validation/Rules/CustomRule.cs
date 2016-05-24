using Aritter.Infras.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class CustomRule<T> : Rule<T>
    {
        protected Func<T, bool> validateFunc;

        public CustomRule(Func<T, bool> validateFunc)
        {
            ThrowHelper.ThrowArgumentNullException(validateFunc, nameof(validateFunc));
            this.validateFunc = validateFunc;
        }

        public override bool Validate(Func<T> source)
        {
            return validateFunc(source());
        }
    }
}
