using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specifications
{
    public sealed class OrSpecification<TEntity> : CompositeSpecification<TEntity>
         where TEntity : class
    {
        private readonly ISpecification<TEntity> rightSideSpecification = null;
        private readonly ISpecification<TEntity> leftSideSpecification = null;

        public OrSpecification(ISpecification<TEntity> leftSide, ISpecification<TEntity> rightSide)
        {
            Check.IsNotNull(leftSide, nameof(leftSide));
            Check.IsNotNull(rightSide, nameof(rightSide));

            this.leftSideSpecification = leftSide;
            this.rightSideSpecification = rightSide;
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
