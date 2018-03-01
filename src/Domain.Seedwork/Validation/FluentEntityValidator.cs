using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public sealed class FluentEntityValidator : IEntityValidator
    {
        public ValidationResult Validate<TValidable>(TValidable item) where TValidable : class, IValidable<TValidable>
        {
            return Validate((IValidable)item);
        }

        public ValidationResult Validate(IValidable item)
        {
            Type itemType = item.GetType();
            if (itemType.IsAssignableFrom(typeof(IValidable)))
                throw new InvalidOperationException("This object is not assignable from a validable object");

            ValidationContract contract = CreateContract(itemType);

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

        private static ValidationContract CreateContract(Type type)
        {
            Type contractType = typeof(ValidationContract<>);
            Type genericType = contractType.MakeGenericType(new Type[] { type });
            ValidationContract contract = (ValidationContract)Activator.CreateInstance(genericType);

            return contract;
        }
    }
}
