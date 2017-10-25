using Ritter.Domain.Seedwork.Rules;
using Ritter.Domain.Seedwork.Rules.Validation;
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
            var result = new ValidationResult();
            var features = GetAllFeatures();

            foreach (var feature in features)
            {
                var featureResult = ValidateFeature(feature);

                foreach (var error in featureResult.Errors)
                {
                    result.AddError(error);
                }
            }

            return result;
        }

        protected virtual void ConfigureFeatures(ValidationFeatureSet<TEntity> featureSet)
        {
        }

        protected ValidationResult Validate(string featureName)
        {
            var feature = GetFeature(featureName);
            return ValidateFeature(feature);
        }

        private ValidationResult ValidateFeature(ValidationFeature<TEntity> feature)
        {
            ValidationResult result = new ValidationResult();

            foreach (var rule in feature?.Rules)
            {
                var ruleResult = ValidateRule(rule);

                foreach (var error in ruleResult.Errors)
                {
                    result.AddError(error);
                }
            }

            return result;
        }

        private ValidationResult ValidateRule(ValidationRule<TEntity> rule)
        {
            var result = new ValidationResult();

            if (!rule.Validate(Instance))
            {
                result.AddError(new ValidationError(rule.ToString()));
            }

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
