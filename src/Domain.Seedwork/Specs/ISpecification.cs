using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Specs
{
    public interface ISpecification<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> SatisfiedBy();
        bool IsSatisfiedBy(TEntity entity);
    }
}
