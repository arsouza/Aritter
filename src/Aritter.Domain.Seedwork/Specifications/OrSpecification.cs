using Aritter.Domain.Seedwork.Aggregates;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specification
{
    /// <summary>
    /// A Logic OR Specification
    /// </summary>
    /// <typeparam name="T">Type of entity that check this specification</typeparam>
    public sealed class OrSpecification<T> : CompositeSpecification<T>
         where T : class, IEntity
    {
        #region Members

        private readonly ISpecification<T> rightSideSpecification = null;
        private readonly ISpecification<T> leftSideSpecification = null;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Default constructor for AndSpecification
        /// </summary>
        /// <param name="leftSide">Left side specification</param>
        /// <param name="rightSide">Right side specification</param>
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

        /// <summary>
        /// Left side specification
        /// </summary>
        public override ISpecification<T> LeftSideSpecification
        {
            get { return leftSideSpecification; }
        }

        /// <summary>
        /// Righ side specification
        /// </summary>
        public override ISpecification<T> RightSideSpecification
        {
            get { return rightSideSpecification; }
        }

        /// <summary>
        /// <see cref="Aritter.Domain.Seedwork.Specification.ISpecification{T}"/>
        /// </summary>
        /// <returns><see cref="Aritter.Domain.Seedwork.Specification.ISpecification{T}"/></returns>
        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            Expression<Func<T, bool>> left = leftSideSpecification.SatisfiedBy();
            Expression<Func<T, bool>> right = rightSideSpecification.SatisfiedBy();

            return (left.Or(right));

        }

        #endregion
    }
}
