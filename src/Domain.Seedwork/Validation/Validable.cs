using System;
using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public abstract class Validable<TEntity> : IValidable<TEntity> where TEntity : class
    {
        private readonly ValidationContext<TEntity> context;

        protected Validable() : base()
        {
            context = new ValidationContext<TEntity>();
        }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            foreach (var rule in context.Rules)
            {
                if (!rule.Validate(this as TEntity))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }

        protected void AddValidations(Action<ValidationContext<TEntity>> validationAction = null)
        {
            validationAction?.Invoke(context);
        }
    }
}