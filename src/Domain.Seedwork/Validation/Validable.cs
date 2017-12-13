using System;
using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public abstract class Validable : IValidable
    {
        private readonly ValidationContext<IValidable> context;

        protected Validable() : base()
        {
            context = new ValidationContext<IValidable>();
        }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            foreach (var rule in context.Rules)
            {
                if (!rule.Validate(this as IValidable))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }

        protected void AddValidations(Action<ValidationContext<IValidable>> validationAction = null)
        {
            validationAction?.Invoke(context);
        }
    }
}