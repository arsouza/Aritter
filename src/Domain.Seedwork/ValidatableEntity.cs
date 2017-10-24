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

        public ICollection<ValidationFeature<TEntity>> GetAllFeatures()
        {
            return featureSet.Features.Select(p => p.Value).ToList();
        }

        public ValidationFeature<TEntity> GetFeature(string name)
        {
            featureSet.Features.TryGetValue(name, out ValidationFeature<TEntity> feature);
            return feature;
        }

        protected virtual void ConfigureFeatures(ValidationFeatureSet<TEntity> featureSet)
        {
        }
    }
}
