using Aritter.Domain.Seedwork.Aggregates;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specification
{
    /// <summary>
    /// A logic AND Specification
    /// </summary>
    /// <typeparam name="TEntity">Type of entity that check this specification</typeparam>
    public sealed class AndSpecification<TEntity> : CompositeSpecification<TEntity>
       where TEntity : class, IEntity
    {
        #region Members

        private readonly ISpecification<TEntity> rightSideSpecification = null;
        private readonly ISpecification<TEntity> leftSideSpecification = null;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Inicia uma nova instância da classe <see cref="{TEntity}" />
        /// </summary>
        /// <param name="leftSide">Left side specification</param>
        /// <param name="rightSide">Right side specification</param>
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

        /// <summary>
        /// Left side specification
        /// </summary>
        public override ISpecification<TEntity> LeftSideSpecification
        {
            get { return leftSideSpecification; }
        }

        /// <summary>
        /// Right side specification
        /// </summary>
        public override ISpecification<TEntity> RightSideSpecification
        {
            get { return rightSideSpecification; }
        }

        /// <summary>
        /// <see cref="Aritter.Domain.Seedwork.Specification.ISpecification{T}"/>
        /// </summary>
        /// <returns><see cref="Aritter.Domain.Seedwork.Specification.ISpecification{T}"/></returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            Expression<Func<TEntity, bool>> left = leftSideSpecification.SatisfiedBy();
            Expression<Func<TEntity, bool>> right = rightSideSpecification.SatisfiedBy();

            return (left.And(right));
        }

        #endregion
    }
}
