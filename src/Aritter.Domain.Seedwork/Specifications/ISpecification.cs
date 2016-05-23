using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specifications
{
    public interface ISpecification<TEntity>
        where TEntity : class, IEntity
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
