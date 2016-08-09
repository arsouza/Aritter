using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Rules.Validation
{
    public abstract class EntityValidator<TEntity> : IEntityValidator<TEntity>
        where TEntity : class, IEntity
    {
        private readonly Dictionary<string, IValidationRule<TEntity>> validations = new Dictionary<string, IValidationRule<TEntity>>();

        protected virtual void AddValidation(string ruleName, IValidationRule<TEntity> rule)
        {
            Check.Against<ArgumentNullException>(rule == null, "Cannot add a null rule instance. Expected a non null reference.");
            Check.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Cannot add a rule with an empty or null rule name.");
            Check.Against<ArgumentException>(validations.ContainsKey(ruleName), "Another rule with the same name already exists. Cannot add duplicate rules.");

            validations.Add(ruleName, rule);
        }

        protected virtual void RemoveValidation(string ruleName)
        {
            Check.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Expected a non empty and non-null rule name.");

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
            Check.Against<ArgumentException>(!validations.ContainsKey(ruleName), $"The rule '{ruleName}' does not exists. Cannot validate.");

            var result = new ValidationResult();
            var rule = validations[ruleName];

            if (!rule.Validate(entity))
            {
                result.AddError(new ValidationError(rule.ValidationMessage, rule.ValidationProperty));
            }

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
