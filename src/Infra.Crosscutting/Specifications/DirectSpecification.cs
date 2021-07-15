using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Specifications
{
    public class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        private readonly Expression<Func<TEntity, bool>> matchingCriteria;

        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            Ensure.ArgumentNotNull(matchingCriteria, nameof(matchingCriteria));
            this.matchingCriteria = matchingCriteria;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy() => matchingCriteria;
    }
}
