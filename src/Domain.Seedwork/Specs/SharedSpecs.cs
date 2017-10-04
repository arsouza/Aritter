using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Specs
{
    public static class SharedSpecs
    {
        public static Specification<TEntity> True<TEntity>()
             where TEntity : class
        {
            return new TrueSpecification<TEntity>();
        }

        public static Specification<TEntity> Direct<TEntity>(Expression<Func<TEntity, bool>> matchingCriteria)
             where TEntity : class
        {
            return new DirectSpecification<TEntity>(matchingCriteria);
        }

        public static Specification<TEntity> Not<TEntity>(ISpecification<TEntity> specification)
             where TEntity : class
        {
            return new NotSpecification<TEntity>(specification);
        }
    }
}
