using Ritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public abstract class EntityValidator<TEntity> : IEntityValidator<TEntity>
        where TEntity : class
    {
        private readonly Dictionary<string, IValidationRule<TEntity>> validations = new Dictionary<string, IValidationRule<TEntity>>();

        protected virtual void AddValidation(string ruleName, IValidationRule<TEntity> rule)
        {
            if (rule is null)
                throw new ArgumentNullException("Cannot add a null rule instance. Expected a non null reference.");

            if (string.IsNullOrEmpty(ruleName))
                throw new ArgumentNullException("Cannot add a rule with an empty or null rule name.");

            if (validations.ContainsKey(ruleName))
                throw new ArgumentException("Another rule with the same name already exists. Cannot add duplicate rules.");

            validations.Add(ruleName, rule);
        }

        protected virtual void RemoveValidation(string ruleName)
        {
            if (string.IsNullOrEmpty(ruleName))
                throw new ArgumentNullException("Expected a non empty and non-null rule name.");

            validations.Remove(ruleName);
        }

        protected virtual void RemoveValidations()
        {
            validations.Clear();
        }

        public virtual ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();

            foreach (var key in validations.Keys)
            {
                var ruleResult = Validate(entity, key);

                foreach (var error in ruleResult.Errors)
                {
                    result.AddError(error);
                }
            }

            return result;
        }

        protected virtual ValidationResult Validate(TEntity entity, string ruleName)
        {
            if (!validations.ContainsKey(ruleName))
                throw new ArgumentException($"The rule '{ruleName}' does not exists. Cannot validate.");

            var result = new ValidationResult();
            var rule = validations[ruleName];

            if (!rule.Validate(entity))
                result.AddError(new ValidationError(rule.ValidationMessage, rule.ValidationProperty));

            return result;
        }

        protected IValidationRule<TEntity> GetValidationRule(string ruleName)
        {
            IValidationRule<TEntity> rule;
            validations.TryGetValue(ruleName, out rule);

            return rule;
        }
    }
}
