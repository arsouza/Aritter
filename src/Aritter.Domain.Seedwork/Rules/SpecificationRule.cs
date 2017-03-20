using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Rules
{
    public abstract class SpecificationRule<TEntity>
        where TEntity : class, IEntity
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
