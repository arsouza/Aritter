using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public abstract class SpecificationRuleBase<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ISpecification<TEntity> rule;

        protected SpecificationRuleBase(ISpecification<TEntity> rule)
        {
            Guard.Against<ArgumentNullException>(rule == null, "Expected a non null and valid ISpecification<TEntity> rule instance.");

            this.rule = rule;
        }

        public bool IsSatisfied(TEntity entity)
        {
            Guard.Against<ArgumentNullException>(entity == null, "Expected a valid non-null entity instance against which the rule can be evaluated.");

            return rule.IsSatisfiedBy(entity);
        }
    }
}
