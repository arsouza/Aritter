using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specifications
{
    public sealed class IsNullSpec<TEntity> : Specification<TEntity>
           where TEntity : class, IEntity
    {
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p == null);
        }
    }
}
