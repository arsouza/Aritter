using System;
using Ritter.Domain.Seedwork.Rules.Validation;

namespace Ritter.Domain.Seedwork
{
    public abstract class Validable<TEntity> : IValidable<TEntity> where TEntity : class
    {
        private readonly ValidationFeature<TEntity> feature;

        protected Validable() : base()
        {
            feature = new ValidationFeature<TEntity>();
        }

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();

            foreach (var rule in feature.Rules)
            {
                if (!rule.Validate(this as TEntity))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }

        protected void AddValidations(Action<ValidationFeature<TEntity>> validationAction = null)
        {
            validationAction?.Invoke(feature);
        }
    }
}