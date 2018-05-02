using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Validations
{
    public abstract class EntityValidator<TEntity> : IEntityValidator<TEntity>
         where TEntity : class
    {
        private IValidationContractCache cache;
        private ValidationContract validationContract;

        public EntityValidator()
        {
            cache = new ValidationContractCache();
            validationContract = cache.GetOrAdd(typeof(ValidationContract<>), typeof(TEntity), CreateContract);
        }

        public ValidationResult Validate(object item)
        {
            Ensure.Argument.Is(item.Is<TEntity>(), $"{nameof(item)} must be a {typeof(TEntity).Name} type.");
            return Validate((TEntity)item);
        }

        public abstract ValidationResult Validate(TEntity item);

        protected abstract void Configure(ValidationContract<TEntity> contract);

        private ValidationContract CreateContract(Type contractType, Type entityType)
        {
            Type genericType = contractType.MakeGenericType(new Type[] { entityType });
            ValidationContract<TEntity> contract = (ValidationContract<TEntity>)Activator.CreateInstance(genericType);

            Configure(contract);

            return contract;
        }
    }
}
