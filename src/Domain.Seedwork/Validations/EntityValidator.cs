using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Extensions;

namespace Ritter.Domain.Validations
{
    public abstract class EntityValidator<TEntity> : IEntityValidator<TEntity>
         where TEntity : class
    {
        public abstract ValidationResult Validate(TEntity item);

        public ValidationResult Validate(object item)
        {
            Ensure.Argument.Is(item.Is<TEntity>(), $"{nameof(item)} must be a {typeof(TEntity).Name} type.");
            return Validate((TEntity)item);
        }
    }
}
