using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Specifications
{
    public sealed class AndSpecification<TEntity> : CompositeSpecification<TEntity>
        where TEntity : class
    {
        public AndSpecification(ISpecification<TEntity> leftSideSpecification, ISpecification<TEntity> rightSideSpecification)
            : base(leftSideSpecification, rightSideSpecification)
        {
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            Expression<Func<TEntity, bool>> left = LeftSideSpecification.SatisfiedBy();
            Expression<Func<TEntity, bool>> right = RightSideSpecification.SatisfiedBy();

            return left.And(right);
        }
    }
}
