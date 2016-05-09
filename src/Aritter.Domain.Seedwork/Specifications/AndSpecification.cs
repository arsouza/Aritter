using System;
using System.Linq.Expressions;
using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Seedwork.Specifications
{
    public sealed class AndSpecification<TEntity> : CompositeSpecification<TEntity>
       where TEntity : class, IEntity
    {
        #region Members

        private readonly ISpecification<TEntity> rightSideSpecification = null;
        private readonly ISpecification<TEntity> leftSideSpecification = null;

        #endregion

        #region Public Constructor

        public AndSpecification(ISpecification<TEntity> leftSide, ISpecification<TEntity> rightSide)
        {
            if (leftSide == (ISpecification<TEntity>)null)
                throw new ArgumentNullException(nameof(leftSide));

            if (rightSide == (ISpecification<TEntity>)null)
                throw new ArgumentNullException(nameof(rightSide));

            this.leftSideSpecification = leftSide;
            this.rightSideSpecification = rightSide;
        }

        #endregion

        #region Composite Specification overrides

        public override ISpecification<TEntity> LeftSideSpecification
        {
            get { return leftSideSpecification; }
        }

        public override ISpecification<TEntity> RightSideSpecification
        {
            get { return rightSideSpecification; }
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            Expression<Func<TEntity, bool>> left = leftSideSpecification.SatisfiedBy();
            Expression<Func<TEntity, bool>> right = rightSideSpecification.SatisfiedBy();

            return left.And(right);
        }

        #endregion
    }
}
