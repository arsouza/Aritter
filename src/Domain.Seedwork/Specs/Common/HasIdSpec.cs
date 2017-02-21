using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specs
{
    public class HasIdSpec<TEntity> : Specification<TEntity>
         where TEntity : class, IEntity
    {
        private readonly int id;

        public HasIdSpec(int id)
        {
            this.id = id;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p != null && p.Id == id);
        }
    }
}
