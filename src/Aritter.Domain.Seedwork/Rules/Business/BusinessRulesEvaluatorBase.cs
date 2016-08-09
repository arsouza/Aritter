using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Rules.Business
{
    public abstract class BusinessRulesEvaluatorBase<TEntity> : IBusinessRulesEvaluator<TEntity>
        where TEntity : class, IEntity
    {
        private readonly Dictionary<string, IBusinessRule<TEntity>> ruleSets = new Dictionary<string, IBusinessRule<TEntity>>();

        protected virtual void AddRule(string ruleName, IBusinessRule<TEntity> rule)
        {
            Check.Against<ArgumentNullException>(rule == null, "Cannot add a null rule instance. Expected a non null reference.");
            Check.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Cannot add a rule with an empty or null rule name.");
            Check.Against<ArgumentException>(ruleSets.ContainsKey(ruleName), "Another rule with the same name already exists. Cannot add duplicate rules.");

            ruleSets.Add(ruleName, rule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            Check.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Expected a non empty and non-null rule name.");

            ruleSets.Remove(ruleName);
        }

        public virtual void Evauluate(TEntity entity)
        {
            Check.Against<ArgumentNullException>(entity == null, "Cannot evaluate rules against a null reference. Expected a valid non-null entity instance.");

            foreach (var key in ruleSets.Keys)
            {
                EvaluateRule(key, entity);
            }
        }

        private void EvaluateRule(string ruleName, TEntity entity)
        {
            Check.Against<ArgumentNullException>(entity == null, "Cannot evaluate a business rule set against a null reference.");

            if (ruleSets.ContainsKey(ruleName))
            {
                ruleSets[ruleName].Evaluate(entity);
            }
        }
    }
}
