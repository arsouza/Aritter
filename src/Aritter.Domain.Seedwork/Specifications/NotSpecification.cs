using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specifications
{
    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, IEntity
    {
        #region Members

        private readonly Expression<Func<TEntity, bool>> originalCriteria;

        #endregion

        #region Constructor

        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {
            if (originalSpecification == (ISpecification<TEntity>)null)
                throw new ArgumentNullException(nameof(originalSpecification));

            originalCriteria = originalSpecification.SatisfiedBy();
        }

        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            if (originalSpecification == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException(nameof(originalSpecification));

            originalCriteria = originalSpecification;
        }

        #endregion

        #region Override Specification methods

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(originalCriteria.Body), originalCriteria.Parameters.Single());
        }

        #endregion
    }
}
