#region license



#endregion

using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Extensions;
using System;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public abstract class EntityValidatorBase<TEntity> : IEntityValidator<TEntity>
        where TEntity : class, IEntity
    {
        private readonly Dictionary<string, IValidationRule<TEntity>> _validations = new Dictionary<string, IValidationRule<TEntity>>();

        protected virtual void AddValidation(string ruleName, IValidationRule<TEntity> rule)
        {
            Guard.Against<ArgumentNullException>(rule == null,
                                                 "Cannot add a null rule instance. Expected a non null reference.");
            Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName),
                                                 "Cannot add a rule with an empty or null rule name.");
            Guard.Against<ArgumentException>(_validations.ContainsKey(ruleName),
                                             "Another rule with the same name already exists. Cannot add duplicate rules.");

            _validations.Add(ruleName, rule);
        }

        protected virtual void RemoveValidation(string ruleName)
        {
            Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Expected a non empty and non-null rule name.");
            _validations.Remove(ruleName);
        }

        public virtual ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();
            _validations.Keys.ForEach(x =>
                                          {
                                              var rule = _validations[x];
                                              if (!rule.Validate(entity))
                                                  result.AddError(new ValidationError(rule.ValidationMessage,
                                                                                        rule.ValidationProperty));
                                          });
            return result;
        }

        protected IValidationRule<TEntity> GetValidationRule(string ruleName)
        {
            IValidationRule<TEntity> rule;
            _validations.TryGetValue(ruleName, out rule);
            return rule;
        }
    }

}
