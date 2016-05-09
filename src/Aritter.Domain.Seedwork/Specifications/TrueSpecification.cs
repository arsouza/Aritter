using System;
using System.Linq.Expressions;
using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Seedwork.Specifications
{
    public sealed class TrueSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, IEntity
    {
        #region Specification overrides

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            bool result = true;

            Expression<Func<TEntity, bool>> trueExpression = t => result;

            return trueExpression;
        }

        #endregion
    }
}
