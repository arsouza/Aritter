using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specs
{
    public interface ISpecification<TEntity>
        where TEntity : class, IEntity
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
        bool IsSatisfiedBy(TEntity entity);
    }
}
