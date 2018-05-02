using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Specifications
{
    public abstract class Specification<TEntity> : ISpecification<TEntity>
         where TEntity : class
    {
        public static Specification<TEntity> operator &(Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
            => new AndSpecification<TEntity>(leftSideSpecification, rightSideSpecification);

        public static Specification<TEntity> operator |(Specification<TEntity> leftSideSpecification, Specification<TEntity> rightSideSpecification)
            => new OrSpecification<TEntity>(leftSideSpecification, rightSideSpecification);

        public static Specification<TEntity> operator !(Specification<TEntity> specification) => new NotSpecification<TEntity>(specification);

        public static bool operator false(Specification<TEntity> specification) => false;

        public static bool operator true(Specification<TEntity> specification) => false;

        public virtual bool IsSatisfiedBy(TEntity entity) => SatisfiedBy().Compile().Invoke(entity);

        public abstract Expression<Func<TEntity, bool>> SatisfiedBy();
    }
}
