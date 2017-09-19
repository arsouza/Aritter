using Ritter.Domain.Seedwork.Specifications;
using Ritter.Infra.Crosscutting.Exceptions;
using System;

namespace Ritter.Domain.Seedwork.Rules
{
    public abstract class SpecificationRule<TEntity>
        where TEntity : class
    {
        protected readonly ISpecification<TEntity> rule;

        protected SpecificationRule(ISpecification<TEntity> rule)
        {
            Check.Against<ArgumentNullException>(rule == null, $"Expected a non null and valid {nameof(rule)} rule instance.");

            this.rule = rule;
        }

        public bool IsSatisfied(TEntity entity)
        {
            Check.Against<ArgumentNullException>(entity == null, "Expected a valid non-null entity instance against which the rule can be evaluated.");

            return rule.IsSatisfiedBy(entity);
        }
    }
}
