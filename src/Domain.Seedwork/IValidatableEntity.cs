using Ritter.Domain.Seedwork.Rules.Validation;
using System.Collections.Generic;

namespace Ritter.Domain.Seedwork
{
    public interface IValidatableEntity<TEntity> : IEntity
        where TEntity : class
    {
        ICollection<ValidationFeature<TEntity>> GetAllFeatures();

        ValidationFeature<TEntity> GetFeature(string name);
    }
}
