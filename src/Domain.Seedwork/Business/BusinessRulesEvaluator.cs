using System.Collections.Generic;
using Ritter.Infra.Crosscutting;

namespace Ritter.Domain.Business
{
    public abstract class BusinessRulesEvaluator<TEntity> : IBusinessRulesEvaluator<TEntity>
        where TEntity : class
    {
        protected readonly Dictionary<string, IBusinessRule<TEntity>> rules = new();

        protected virtual void AddRule(string ruleName, IBusinessRule<TEntity> rule)
        {
            Ensure.ArgumentNotNullOrEmpty(ruleName, nameof(ruleName), "Cannot add a rule with an empty or null rule name.");
            Ensure.ArgumentNotNull(rule, nameof(rule), "Cannot add a null rule instance. Expected a non null reference.");
            Ensure.ArgumentIs(!rules.ContainsKey(ruleName), "Another rule with the same name already exists. Cannot add duplicate rules.");

            rules.Add(ruleName, rule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            Ensure.ArgumentNotNullOrEmpty(ruleName, nameof(ruleName), "Expected a non empty and non-null rule name.");
            rules.Remove(ruleName);
        }

        public virtual void Evaluate(TEntity entity)
        {
            Ensure.ArgumentNotNull(entity, nameof(entity), "Cannot evaluate rules against a null reference. Expected a valid non-null entity instance.");

            foreach (string key in rules.Keys)
            {
                Evaluate(entity, key);
            }
        }

        public virtual void Evaluate(TEntity entity, string ruleName)
        {
            Ensure.ArgumentNotNull(entity, nameof(entity), "Cannot evaluate a business rule set against a null reference.");
            Ensure.ArgumentNotNullOrEmpty(ruleName, nameof(ruleName), "Rule name is required.");

            if (rules.ContainsKey(ruleName))
            {
                rules[ruleName].Evaluate(entity);
            }
        }
    }
}
