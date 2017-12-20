using Ritter.Domain.Seedwork.Validation;
using System;

namespace Ritter.Domain.Seedwork.Validation
{
    public abstract class Validable : IValidable
    {
        public virtual ValidationResult Validate()
        {
            return null;
        }
    }
}

/*
namespace Ritter.Domain.Seedwork.Validation
{
    public abstract class Validable<TValidable> : IValidable<TValidable> where TValidable : class
    {
        private readonly ValidationContract<TValidable> contract;

        protected Validable() : base()
        {
            contract = new ValidationContract<TValidable>();
        }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            foreach (var rule in contract.Rules)
            {
                if (!rule.Validate(this as TValidable))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }

        protected void AddValidations(Action<ValidationContract<TValidable>> validationAction = null)
        {
            validationAction?.Invoke(contract);
        }
    }
}
 */