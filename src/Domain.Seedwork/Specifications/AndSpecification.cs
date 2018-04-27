using Ritter.Infra.Crosscutting;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Specifications
{
    public sealed class AndSpecification<TEntity> : CompositeSpecification<TEntity>
       where TEntity : class
    {
        private readonly ISpecification<TEntity> rightSideSpecification = null;
        private readonly ISpecification<TEntity> leftSideSpecification = null;

        public AndSpecification(ISpecification<TEntity> leftSideSpecification, ISpecification<TEntity> rightSideSpecification)
        {
            Ensure.Argument.NotNull(leftSideSpecification, nameof(leftSideSpecification));
            Ensure.Argument.NotNull(rightSideSpecification, nameof(rightSideSpecification));

            this.leftSideSpecification = leftSideSpecification;
            this.rightSideSpecification = rightSideSpecification;
        }

        public override ISpecification<TEntity> LeftSideSpecification => leftSideSpecification;

        public override ISpecification<TEntity> RightSideSpecification => rightSideSpecification;

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            Expression<Func<TEntity, bool>> left = leftSideSpecification.SatisfiedBy();
            Expression<Func<TEntity, bool>> right = rightSideSpecification.SatisfiedBy();

            return left.And(right);
        }
    }
}
