using System;
using System.Linq.Expressions;
using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Seedwork.Specifications
{
    public sealed class OrSpecification<T> : CompositeSpecification<T>
         where T : class, IEntity
    {
        #region Members

        private readonly ISpecification<T> rightSideSpecification = null;
        private readonly ISpecification<T> leftSideSpecification = null;

        #endregion

        #region Public Constructor

        public OrSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            if (leftSide == (ISpecification<T>)null)
                throw new ArgumentNullException("leftSide");

            if (rightSide == (ISpecification<T>)null)
                throw new ArgumentNullException("rightSide");

            this.leftSideSpecification = leftSide;
            this.rightSideSpecification = rightSide;
        }

        #endregion

        #region Composite Specification overrides

        public override ISpecification<T> LeftSideSpecification
        {
            get { return leftSideSpecification; }
        }

        public override ISpecification<T> RightSideSpecification
        {
            get { return rightSideSpecification; }
        }

        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = leftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = rightSideSpecification.SatisfiedBy();

            return left.Or(right);
        }

        #endregion
    }
}
