using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Specifications
{
    public class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        private readonly Expression<Func<TEntity, bool>> matchingCriteria;

        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            this.matchingCriteria = matchingCriteria ?? throw new ArgumentNullException(nameof(matchingCriteria));
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return matchingCriteria;
        }
    }
}
