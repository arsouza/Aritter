using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specs
{
    public sealed class OrSpecification<T> : CompositeSpecification<T>
         where T : class, IEntity
    {
        private readonly ISpecification<T> rightSideSpecification = null;
        private readonly ISpecification<T> leftSideSpecification = null;

        public OrSpecification(ISpecification<T> leftSide, ISpecification<T> rightSide)
        {
            Check.IsNotNull(leftSide, nameof(leftSide));
            Check.IsNotNull(rightSide, nameof(rightSide));

            this.leftSideSpecification = leftSide;
            this.rightSideSpecification = rightSide;
        }

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
    }
}
