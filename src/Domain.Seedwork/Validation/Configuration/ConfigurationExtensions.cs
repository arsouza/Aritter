using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public static class ConfigurationExtensions
    {
        public static ValidationContract<TValidable> Validate<TValidable>(this TValidable validable, Action<ValidationContract<TValidable>> configAction) where TValidable : class, IValidable
        {
            if (validable is null)
                throw new ArgumentNullException(nameof(validable));

            ValidationContract<TValidable> contract = new ValidationContract<TValidable>();

            configAction?.Invoke(contract);
            return contract;
        }
    }
}