using Ritter.Domain.Seedwork.Rules;
using Ritter.Domain.Seedwork.Rules.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ritter.Domain.Seedwork
{
    public abstract class ValidatableEntity<TEntity> : Entity, IValidatableEntity<TEntity>
          where TEntity : class
    {
        private ValidationFeatureSet<TEntity> featureSet;

        public ValidatableEntity()
            : base()
        {
            featureSet = new ValidationFeatureSet<TEntity>();
            ConfigureFeatures(featureSet);
        }

        protected TEntity Instance => this as TEntity;

        public ValidationResult Validate()
        {
            ValidationResult result = new ValidationResult();
            ICollection<ValidationFeature<TEntity>> features = GetAllFeatures();

            foreach (var feature in features)
                result.Append(ValidateFeature(feature));

            return result;
        }

        protected virtual void ConfigureFeatures(ValidationFeatureSet<TEntity> featureSet)
        {
        }

        protected ValidationResult Validate(string featureName)
        {
            ValidationFeature<TEntity> feature = GetFeature(featureName);
            return ValidateFeature(feature);
        }

        private ValidationResult ValidateFeature(ValidationFeature<TEntity> feature)
        {
            if (feature is null)
                throw new ArgumentNullException(nameof(feature));

            ValidationResult result = new ValidationResult();

            foreach (var rule in feature.Rules)
                result.Append(ValidateRule(rule));

            return result;
        }

        private ValidationResult ValidateRule(ValidationRule<TEntity> rule)
        {
            ValidationResult result = new ValidationResult();

            if (!rule.Validate(Instance))
                result.AddError(rule.Property, rule.Message);

            return result;
        }

        private ICollection<ValidationFeature<TEntity>> GetAllFeatures()
        {
            return featureSet.Features.Select(p => p.Value).ToList();
        }

        private ValidationFeature<TEntity> GetFeature(string name)
        {
            featureSet.Features.TryGetValue(name, out ValidationFeature<TEntity> feature);
            return feature;
        }
    }
}
