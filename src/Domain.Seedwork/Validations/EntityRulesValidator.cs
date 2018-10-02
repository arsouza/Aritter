using Ritter.Infra.Crosscutting;
using System;

namespace Ritter.Domain.Validations
{
    public sealed class EntityRulesValidator : EntityValidator
    {
        private readonly IValidationContextCache cache = ValidationContextCache.Current();

        public override ValidationResult Validate(object item)
        {
            Ensure.Argument.NotNull(item, nameof(item));
            Ensure.Argument.Is(item.Is<IValidatableEntity>(), $"The type of {nameof(item)} should be a {nameof(IValidatableEntity)}");

            var context = cache.GetOrAdd(item.GetType(), (Type type) =>
            {
                var ctx = new ValidationContext();
                item.As<IValidatableEntity>()?.ValidationSetup(ctx);

                return ctx;
            });

            var rulesResult = ValidateRules(item, context);
            var includesResult = ValidateIncludes(item, context);

            return rulesResult.Append(includesResult);
        }

        private static ValidationResult ValidateRules(object item, ValidationContext context)
        {
            var result = new ValidationResult();

            foreach (var rule in context.Rules)
            {
                if (!rule.IsValid(item))
                    result.AddError(rule.Property, rule.Message);
            }

            return result;
        }

        private ValidationResult ValidateIncludes(object item, ValidationContext context)
        {
            var result = new ValidationResult();

            IValidatableEntity entity;

            foreach (var include in context.Includes)
            {
                entity = include
                    .Compile()
                    .DynamicInvoke(item)
                    .As<IValidatableEntity>();

                result = result.Append(Validate(entity));
            }

            return result;
        }
    }
}
