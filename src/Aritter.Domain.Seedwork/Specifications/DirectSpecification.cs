using System;
using System.Linq.Expressions;
using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Seedwork.Specifications
{
    public class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, IEntity
    {
        #region Members

        private readonly Expression<Func<TEntity, bool>> matchingCriteria;

        #endregion

        #region Constructor

        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            if (matchingCriteria == null)
                throw new ArgumentNullException(nameof(matchingCriteria));

            this.matchingCriteria = matchingCriteria;
        }

        #endregion

        #region Override

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return matchingCriteria;
        }

        #endregion
    }
}
