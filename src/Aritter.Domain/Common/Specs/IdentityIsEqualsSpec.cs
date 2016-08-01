using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Common.Specs
{
    public sealed class IdentityIsEqualsSpec<TEntity> : Specification<TEntity>
         where TEntity : class, IEntity
    {
        private readonly Guid identity;

        public IdentityIsEqualsSpec(Guid identity)
        {
            this.identity = identity;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p.UID == identity);
        }
    }
}
