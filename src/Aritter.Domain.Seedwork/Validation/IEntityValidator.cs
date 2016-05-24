using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Validation
{
    /// <summary>
    /// The entity validator base contract
    /// </summary>
    public interface IEntityValidator
    {
        bool IsValid<TEntity>(TEntity item) where TEntity : class, IValidatableEntity;

        bool IsValid<TEntity>(TEntity item, Feature<TEntity> feature) where TEntity : class, IValidatableEntity;

        IEnumerable<string> GetValidationResult<TEntity>(TEntity item) where TEntity : class, IValidatableEntity;

        IEnumerable<string> GetValidationResult<TEntity>(TEntity item, Feature<TEntity> feature) where TEntity : class, IValidatableEntity;
    }
}
