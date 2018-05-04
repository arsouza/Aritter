using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Specifications
{
    public interface ISpecification<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
        bool IsSatisfiedBy(TEntity entity);
    }
}
