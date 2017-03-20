using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Rules.Business
{
    public class BusinessRule<TEntity> : SpecificationRule<TEntity>, IBusinessRule<TEntity>
        where TEntity : class, IEntity
    {
        private readonly Action<TEntity> action;

        public BusinessRule(ISpecification<TEntity> rule, Action<TEntity> action) : base(rule)
        {
            Check.Against<ArgumentNullException>(action == null, $"Please provide a valid non null {nameof(action)} delegate instance.");
            this.action = action;
        }

        public void Evaluate(TEntity entity)
        {
            Check.Against<ArgumentNullException>(entity == null, "Cannot evaulate a business rule against a null reference.");

            if (IsSatisfied(entity))
            {
                action(entity);
            }
        }
    }
}
