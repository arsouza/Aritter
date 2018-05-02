using Ritter.Domain.Validation.Caching;
using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Validation.Fluent
{
    public sealed class FluentValidator : IFluentValidator
    {
        private readonly IValidationContractCacheProvider cachingProvider;

        public FluentValidator(IValidationContractCacheProvider cachingProvider)
        {
            this.cachingProvider = cachingProvider;
        }

        public ValidationResult Validate<TValidable>(TValidable item) where TValidable : class, IValidable<TValidable>
        {
            return Validate((IValidable)item);
        }

        public ValidationResult Validate(object item)
        {
            return Validate(item as IValidable);
        }

        public ValidationResult Validate(IValidable item)
        {
            Ensure.Argument.NotNull(item, nameof(item));
            Ensure.That<InvalidOperationException>(item.Is<IValidable>(), $"This object is not a {typeof(IValidable).Name} object");

            var contract = ValidationContractFactory.EnsureContract(item.GetType(), cachingProvider);

            item.SetupValidation(contract);

            var validationResult = ValidateRules(item, contract);
            var includeValidationResult = ValidateIncludes(item, contract);

            validationResult.Append(includeValidationResult);

            return validationResult;
        }

        private ValidationResult ValidateIncludes(IValidable item, ValidationContract contract)
        {
            var result = new ValidationResult();

            foreach (var include in contract.Includes)
            {
                IValidable includeItem = (IValidable)include.Value.Compile().DynamicInvoke(item);
                result.Append(Validate(includeItem));
            }

            return result;
        }

        private static ValidationResult ValidateRules(IValidable item, ValidationContract contract)
        {
            var result = new ValidationResult();

            foreach (var rule in contract.Rules)
            {
                if (!rule.Validate(item))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }
    }
}
