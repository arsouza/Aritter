using Domain.Seedwork.Validation;
using Domain.Seedwork.Validation.Caching;
using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Seedwork.Validation
{
    public sealed class FluentValidator : IValidator
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

        public ValidationResult Validate(IValidable item)
        {
            Type itemType = item.GetType();

            Ensure.That<InvalidOperationException>(item is IValidable, $"This object is not a {typeof(IValidable).Name} object");

            ValidationContract contract = ValidationContractFactory.EnsureContract(itemType, cachingProvider);

            item.SetupValidation(contract);

            var validationResult = ValidateRules(item, contract);
            var includeValidationResult = ValidateIncludes(item, contract);

            validationResult.Append(includeValidationResult);

            return validationResult;
        }

        private ValidationResult ValidateIncludes(IValidable item, ValidationContract contract)
        {
            ValidationResult result = new ValidationResult();

            foreach (var include in contract.Includes)
            {
                IValidable includeItem = (IValidable)include.Value.Compile().DynamicInvoke(item);
                result.Append(Validate(includeItem));
            }

            return result;
        }

        private static ValidationResult ValidateRules(IValidable item, ValidationContract contract)
        {
            ValidationResult result = new ValidationResult();

            foreach (var rule in contract.Rules)
            {
                if (!rule.Validate(item))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }
    }
}
