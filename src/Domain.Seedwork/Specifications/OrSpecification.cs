using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Specifications
{
    public sealed class OrSpecification<TEntity> : CompositeSpecification<TEntity>
         where TEntity : class
    {
        public OrSpecification(ISpecification<TEntity> leftSideSpecification, ISpecification<TEntity> rightSideSpecification)
            : base(leftSideSpecification, rightSideSpecification)
        {
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            Expression<Func<TEntity, bool>> left = LeftSideSpecification.SatisfiedBy();
            Expression<Func<TEntity, bool>> right = RightSideSpecification.SatisfiedBy();

            return left.Or(right);
        }
    }
}
