using Aritter.Domain.Seedwork.Aggregates;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specification
{

    /// <summary>
    /// True specification
    /// </summary>
    /// <typeparam name="TEntity">Type of entity in this specification</typeparam>
    public sealed class TrueSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, IEntity
    {
        #region Specification overrides

        /// <summary>
        /// <see cref="Aritter.Domain.Seedwork.Specification.Specification{TEntity}"/>
        /// </summary>
        /// <returns><see cref="Aritter.Domain.Seedwork.Specification.Specification{TEntity}"/></returns>
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            //Create "result variable" transform adhoc execution plan in prepared plan
            //for more info: http://geeks.ms/blogs/unai/2010/07/91/ef-4-0-performance-tips-1.aspx
            bool result = true;

            Expression<Func<TEntity, bool>> trueExpression = t => result;
            return trueExpression;
        }

        #endregion
    }
}
