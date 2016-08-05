using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specs
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
            Guard.IsNotNull(leftSide, nameof(leftSide));
            Guard.IsNotNull(rightSide, nameof(rightSide));

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
