using System;
using System.Linq.Expressions;
using Ritter.Infra.Crosscutting;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public static class ConfigurationExtensions
    {
        public static ValidationContract<TValidable> Validate<TValidable>(this TValidable validable, Action<ValidationContract<TValidable>> configAction) where TValidable : class, IValidable<TValidable>
        {
            Ensure.Argument.NotNull(validable, nameof(validable));

            ValidationContract<TValidable> contract = new ValidationContract<TValidable>();

            configAction?.Invoke(contract);
            return contract;
        }
    }
}
