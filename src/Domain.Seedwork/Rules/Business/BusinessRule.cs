using Ritter.Domain.Seedwork.Specifications;
using Ritter.Infra.Crosscutting.Exceptions;
using System;

namespace Ritter.Domain.Seedwork.Rules.Business
{
    public class BusinessRule<TEntity> : SpecificationRule<TEntity>, IBusinessRule<TEntity>
        where TEntity : class
    {
        private readonly Action<TEntity> action;

        public BusinessRule(ISpecification<TEntity> rule, Action<TEntity> action) : base(rule)
        {
            this.action = action ?? throw new ArgumentNullException($"Please provide a valid non null {nameof(action)} delegate instance.");
        }

        public void Evaluate(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Cannot evaulate a business rule against a null reference.");

            if (IsSatisfied(entity))
                action(entity);
        }
    }
}
