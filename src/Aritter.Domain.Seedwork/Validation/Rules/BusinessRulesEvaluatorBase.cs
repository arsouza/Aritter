#region license



#endregion

using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Extensions;
using System;
using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public abstract class BusinessRulesEvaluatorBase<TEntity> : IBusinessRulesEvaluator<TEntity>
        where TEntity : class, IEntity
    {
        private readonly Dictionary<string, IBusinessRule<TEntity>> _ruleSets = new Dictionary<string, IBusinessRule<TEntity>>();

        protected virtual void AddRule(string ruleName, IBusinessRule<TEntity> rule)
        {
            Guard.Against<ArgumentNullException>(rule == null,
                                                 "Cannot add a null rule instance. Expected a non null reference.");
            Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName),
                                                 "Cannot add a rule with an empty or null rule name.");
            Guard.Against<ArgumentException>(_ruleSets.ContainsKey(ruleName),
                                             "Another rule with the same name already exists. Cannot add duplicate rules.");

            _ruleSets.Add(ruleName, rule);
        }

        protected virtual void RemoveRule(string ruleName)
        {
            Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Expected a non empty and non-null rule name.");
            _ruleSets.Remove(ruleName);
        }

        public virtual void Evauluate(TEntity entity)
        {
            Guard.Against<ArgumentNullException>(entity == null,
                                                 "Cannot evaluate rules against a null reference. Expected a valid non-null entity instance.");
            _ruleSets.Keys.ForEach(x => EvaluateRule(x, entity));
        }

        private void EvaluateRule(string ruleName, TEntity entity)
        {
            Guard.Against<ArgumentNullException>(entity == null, "Cannot evaluate a business rule set against a null reference.");
            if (_ruleSets.ContainsKey(ruleName))
            {
                _ruleSets[ruleName].Evaluate(entity);
            }
        }
    }
}
