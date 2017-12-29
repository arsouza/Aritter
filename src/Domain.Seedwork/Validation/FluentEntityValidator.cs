using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public sealed class FluentEntityValidator : IEntityValidator
    {
        public ValidationResult Validate<TValidable>(TValidable item) where TValidable : class, IValidable
        {
            ValidationResult result = new ValidationResult();
            IValidationContract<TValidable> contract = item.SetupValidation<TValidable>();

            foreach (var rule in contract.Rules)
            {
                if (!rule.Validate(item))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }
    }
}