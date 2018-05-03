using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Validations
{
    public abstract class EntityValidator<TEntity> : IEntityValidator<TEntity>
         where TEntity : class
    {
        private IValidationContractCache cache;

        private Type contractType = typeof(ValidationContract<>);
        private Type entityType = typeof(TEntity);

        public EntityValidator()
        {
            cache = ValidationContractCache.Current();
        }

        public ValidationResult Validate(object item)
        {
            Ensure.Argument.Is(item.Is<TEntity>(), $"{nameof(item)} must be a {typeof(TEntity).Name} type.");
            return Validate((TEntity)item);
        }

        public ValidationResult Validate(TEntity item)
        {
            Ensure.Argument.NotNull(item, nameof(item));

            var contract = cache.GetOrAdd(contractType, entityType, CreateContract);
            var rulesResult = ValidateRules(item, contract);
            var includesResult = ValidateIncludes(item, contract);

            return rulesResult.Append(includesResult);
        }

        protected abstract void Configure(ValidationContract<TEntity> contract);

        private ValidationContract CreateContract(Type contractType, Type entityType)
        {
            var contract = new ValidationContract<TEntity>();
            Configure(contract);

            return contract;
        }

        private static ValidationResult ValidateRules(TEntity item, ValidationContract contract)
        {
            var result = new ValidationResult();

            foreach (var rule in contract.Rules)
            {
                if (!rule.Validate(item))
                    result.AddError(rule.Property, rule.Message);
            }
            return result;
        }

        private ValidationResult ValidateIncludes(TEntity item, ValidationContract contract)
        {
            object entity;
            IEntityValidator validator;
            var result = new ValidationResult();

            foreach (var include in contract.Includes)
            {
                validator = include.Key;
                entity = include.Value.Compile().DynamicInvoke(item);
                result = result.Append(validator.Validate(entity));
            }

            return result;
        }
    }
}
