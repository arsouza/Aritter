using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Common.Specs
{
    public sealed class IsPersistedSpec<TEntity> : Specification<TEntity>
         where TEntity : class, IEntity
    {
        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p.Id > 0);
        }
    }
}
