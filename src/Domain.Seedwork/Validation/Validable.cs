using System;
using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public abstract class Validable : IValidable
    {
        private readonly ValidationContract<IValidable> contract;

        protected Validable() : base()
        {
            contract = new ValidationContract<IValidable>();
        }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            foreach (var rule in contract.Rules)
            {
                if (!rule.Validate(this as IValidable))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }

        protected void AddValidations(Action<ValidationContract<IValidable>> validationAction = null)
        {
            validationAction?.Invoke(contract);
        }
    }
}