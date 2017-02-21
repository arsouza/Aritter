using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specs
{
    public sealed class IsTransientSpec<TEntity> : Specification<TEntity>
         where TEntity : class, IEntity
    {
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p != null && p.Id == 0);
        }
    }
}
