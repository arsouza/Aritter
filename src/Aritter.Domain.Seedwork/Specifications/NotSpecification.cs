﻿using Aritter.Domain.Seedwork.Aggregates;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specification
{
    /// <summary>
    /// NotEspecification convert a original
    /// specification with NOT logic operator
    /// </summary>
    /// <typeparam name="TEntity">Type of element for this specificaiton</typeparam>
    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, IEntity
    {
        #region Members

        private readonly Expression<Func<TEntity, bool>> originalCriteria;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for NotSpecificaiton
        /// </summary>
        /// <param name="originalSpecification">Original specification</param>
        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {

            if (originalSpecification == (ISpecification<TEntity>)null)
                throw new ArgumentNullException(nameof(originalSpecification));

            originalCriteria = originalSpecification.SatisfiedBy();
        }

        /// <summary>
        /// Constructor for NotSpecification
        /// </summary>
        /// <param name="originalSpecification">Original specificaiton</param>
        public NotSpecification(Expression<Func<TEntity, bool>> originalSpecification)
        {
            if (originalSpecification == (Expression<Func<TEntity, bool>>)null)
                throw new ArgumentNullException("originalSpecification");

            originalCriteria = originalSpecification;
        }

        #endregion

        #region Override Specification methods

        /// <summary>
        /// <see cref="Aritter.Domain.Seedwork.Specification.ISpecification{TEntity}"/>
        /// </summary>
        /// <returns><see cref="Aritter.Domain.Seedwork.Specification.ISpecification{TEntity}"/></returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {

            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(originalCriteria.Body),
                                                         originalCriteria.Parameters.Single());
        }

        #endregion
    }
}
