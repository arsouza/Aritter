using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Validations
{
    public abstract class EntityValidator<TEntity> : IEntityValidator<TEntity>
         where TEntity : class
    {
        public ValidationResult Validate(object item)
        {
            Ensure.Argument.Is(item.Is<TEntity>(), $"{nameof(item)} must be a {typeof(TEntity).Name} type.");
            return Validate((TEntity)item);
        }

        public abstract ValidationResult Validate(TEntity item);

        protected abstract void Configure(ValidationContract<TEntity> contract);
    }
}
