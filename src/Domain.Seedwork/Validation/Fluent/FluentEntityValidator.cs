using Ritter.Domain.Seedwork.Validation;

namespace Domain.Seedwork.Validation.Fluent
{
    public class FluentEntityValidator : IEntityValidator
    {
        public ValidationResult Validate<TValidable>(TValidable item) where TValidable : class, IValidable
        {
            ValidationResult result = new ValidationResult();
            IValidationContract<TValidable> contract = item.ConfigureValidation<TValidable>();

            foreach (var rule in contract.Rules)
            {
                if (!rule.Validate(item))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }
    }
}