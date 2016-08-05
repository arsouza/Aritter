using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specs
{
    public sealed class HasUIDSpec<TEntity> : Specification<TEntity>
         where TEntity : class, IEntity
    {
        private readonly Guid uid;

        public HasUIDSpec(Guid uid)
        {
            this.uid = uid;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p != null && p.UID == uid);
        }
    }
}
