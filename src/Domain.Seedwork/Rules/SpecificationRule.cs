using System;
using Ritter.Domain.Seedwork.Specs;
using Ritter.Infra.Crosscutting.Exceptions;

namespace Ritter.Domain.Seedwork.Rules
{
    public abstract class SpecificationRule<TEntity>
        where TEntity : class
    {
        protected readonly ISpecification<TEntity> rule;

        protected SpecificationRule(ISpecification<TEntity> rule)
        {
            this.rule = rule ?? throw new ArgumentNullException($"Expected a non null and valid {nameof(rule)} rule instance.");
        }

        public bool IsSatisfied(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Expected a valid non-null entity instance against which the rule can be evaluated.");

            return rule.IsSatisfiedBy(entity);
        }
    }
}
