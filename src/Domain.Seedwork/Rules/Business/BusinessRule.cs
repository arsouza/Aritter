using Ritter.Domain.Seedwork.Specs;
using System;

namespace Ritter.Domain.Seedwork.Rules.Business
{
    public class BusinessRule<TEntity> : IBusinessRule<TEntity>
        where TEntity : class
    {
        private readonly ISpecification<TEntity> rule;
        private readonly Action<TEntity> action;

        public BusinessRule(ISpecification<TEntity> rule, Action<TEntity> action)
        {
            this.rule = rule ?? throw new ArgumentNullException($"Please provide a valid non null {nameof(rule)} delegate instance.");
            this.action = action ?? throw new ArgumentNullException($"Please provide a valid non null {nameof(action)} delegate instance.");
        }

        public void Evaluate(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Cannot evaulate a business rule against a null reference.");

            if (rule.IsSatisfiedBy(entity))
                action(entity);
        }
    }
}
