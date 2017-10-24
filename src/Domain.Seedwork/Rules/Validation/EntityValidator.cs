namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public abstract class EntityValidator<TEntity> : IEntityValidator<TEntity>
        where TEntity : class, IValidatableEntity<TEntity>
    {
        public virtual ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();
            var features = entity.GetAllFeatures();

            foreach (var feature in features)
            {
                var featureResult = ValidateFeature(entity, feature);

                foreach (var error in featureResult.Errors)
                {
                    result.AddError(error);
                }
            }

            return result;
        }

        protected virtual ValidationResult Validate(TEntity entity, string featureName)
        {
            var feature = entity.GetFeature(featureName);
            return ValidateFeature(entity, feature);
        }

        protected virtual ValidationResult ValidateFeature(TEntity entity, ValidationFeature<TEntity> feature)
        {
            ValidationResult result = new ValidationResult();

            foreach (var rule in feature?.Rules)
            {
                var ruleResult = ValidateRule(entity, rule);

                foreach (var error in ruleResult.Errors)
                {
                    result.AddError(error);
                }
            }

            return result;
        }

        protected virtual ValidationResult ValidateRule(TEntity entity, ValidationRule<TEntity> rule)
        {
            var result = new ValidationResult();

            if (!rule.Validate(entity))
            {
                result.AddError(new ValidationError(rule.Property, rule.Message));
            }

            return result;
        }
    }
}
