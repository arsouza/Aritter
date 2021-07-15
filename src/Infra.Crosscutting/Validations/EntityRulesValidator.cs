using System;
using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting.Validations
{
    public sealed class EntityRulesValidator : EntityValidator
    {
        private readonly IValidationContextCache cache = ValidationContextCache.Current();

        internal EntityRulesValidator()
        {
        }

        public override ValidationResult Validate(object item)
        {
            Ensure.ArgumentNotNull(item, nameof(item));
            Ensure.ArgumentIs(item is IValidatable, $"The type of {nameof(item)} should be a {nameof(IValidatable)}");

            ValidationContext context = cache.GetOrAdd(item.GetType(), (Type type) =>
            {
                ValidationContext ctx = CreateGenericContext(item.GetType());

                if (item is IValidatable validatable)
                {
                    validatable.AddValidations(ctx);
                }

                return ctx;
            });

            ValidationResult rulesResult = ValidateRules(item, context);
            ValidationResult includesResult = ValidateIncludes(item, context);

            return rulesResult.Append(includesResult);
        }

        private static ValidationResult ValidateRules(object item, ValidationContext context)
        {
            ValidationResult result = new ValidationResult();

            foreach (Rules.IValidationRule rule in context.Rules)
            {
                if (!rule.IsValid(item))
                {
                    result.AddError(rule.Property, rule.Message);
                }
            }

            return result;
        }

        private ValidationResult ValidateIncludes(object obj, ValidationContext context)
        {
            ValidationResult result = new ValidationResult();

            object includeObject;

            foreach (System.Linq.Expressions.LambdaExpression include in context.Includes)
            {
                includeObject = include.Compile().DynamicInvoke(obj);

                if (includeObject is null)
                    continue;

                if (includeObject is IValidatable entity)
                {
                    result = result.Append(Validate(entity));
                }
                else if (includeObject is IEnumerable<IValidatable> entities)
                {
                    foreach (var item in entities)
                    {
                        result = result.Append(Validate(item));
                    }
                }
            }

            foreach (var includes in context.IncludeCollections)
            {
                foreach (var include in includes)
                {
                    includeObject = include.Compile().DynamicInvoke(obj);

                if (includeObject is null)
                    continue;

                if (includeObject is IValidatable entity)
                {
                    result = result.Append(Validate(entity));
                }
                else if (includeObject is IEnumerable<IValidatable> entities)
                {
                    foreach (var item in entities)
                    {
                        result = result.Append(Validate(item));
                    }
                }
            }

            return result;
        }

        private static ValidationContext CreateGenericContext(Type itemType)
        {
            Type[] typeArgs = { itemType };
            Type contextType = typeof(ValidationContext<>);
            Type genericType = contextType.MakeGenericType(typeArgs);

            return Activator.CreateInstance(genericType) as ValidationContext;
        }
    }
}
