using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Specifications
{
    public sealed class OrSpecification<TEntity> : CompositeSpecification<TEntity>
         where TEntity : class
    {
        private readonly ISpecification<TEntity> rightSideSpecification = null;
        private readonly ISpecification<TEntity> leftSideSpecification = null;

        public OrSpecification(ISpecification<TEntity> leftSideSpecification, ISpecification<TEntity> rightSideSpecification)
        {
            this.leftSideSpecification = leftSideSpecification ?? throw new ArgumentNullException(nameof(leftSideSpecification)); ;
            this.rightSideSpecification = rightSideSpecification ?? throw new ArgumentNullException(nameof(rightSideSpecification));
        }

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

            return left.Or(right);
        }
    }
}
