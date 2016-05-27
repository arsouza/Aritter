using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class BusinessRule<TEntity> : SpecificationRuleBase<TEntity>, IBusinessRule<TEntity>
        where TEntity : class, IEntity
    {
        private readonly Action<TEntity> action;
        public BusinessRule(ISpecification<TEntity> rule, Action<TEntity> action) : base(rule)
        {
            Guard.Against<ArgumentNullException>(action == null, "Please provide a valid non null Action<TEntity> delegate instance.");
            this.action = action;
        }

        public void Evaluate(TEntity entity)
        {
            Guard.Against<ArgumentNullException>(entity == null, "Cannot evaulate a business rule against a null reference.");

            if (IsSatisfied(entity))
            {
                action(entity);
            }
        }
    }
}
