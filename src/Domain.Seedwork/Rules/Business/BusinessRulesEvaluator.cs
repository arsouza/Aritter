using System;
using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Rules.Business
{
    public abstract class BusinessRulesEvaluator<TEntity> : IBusinessRulesEvaluator<TEntity>
        where TEntity : class
    {
        private readonly Dictionary<string, IBusinessRule<TEntity>> rules = new Dictionary<string, IBusinessRule<TEntity>>();

        protected virtual void AddRule(string ruleName, IBusinessRule<TEntity> rule)
        {
            if (rule is null)
                throw new ArgumentNullException("Cannot add a null rule instance. Expected a non null reference.");

            if (string.IsNullOrEmpty(ruleName))
                throw new ArgumentNullException("Cannot add a rule with an empty or null rule name.");

            if (rules.ContainsKey(ruleName))
                throw new ArgumentException("Another rule with the same name already exists. Cannot add duplicate rules.");

            rules.Add(ruleName, rule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            if (string.IsNullOrEmpty(ruleName))
                throw new ArgumentNullException("Expected a non empty and non-null rule name.");

            rules.Remove(ruleName);
        }

        public virtual void Evauluate(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Cannot evaluate rules against a null reference. Expected a valid non-null entity instance.");

            foreach (var key in rules.Keys)
            {
                Evauluate(entity, key);
            }
        }

        private void Evauluate(TEntity entity, string ruleName)
        {
            if (entity is null)
                throw new ArgumentNullException("Cannot evaluate a business rule set against a null reference.");

            if (rules.ContainsKey(ruleName))
            {
                rules[ruleName].Evaluate(entity);
            }
        }
    }
}
