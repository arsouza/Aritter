using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Common.Specs
{
    public class IdIsEqualsSpec<TEntity> : Specification<TEntity>
         where TEntity : class, IEntity
    {
        private readonly int id;

        public IdIsEqualsSpec(int id)
        {
            this.id = id;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p.Id == id);
        }
    }
}
