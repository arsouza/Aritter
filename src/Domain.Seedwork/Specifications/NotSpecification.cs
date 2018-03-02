using System;
using System.Linq;
using System.Linq.Expressions;
using Ritter.Infra.Crosscutting;

namespace Ritter.Domain.Seedwork.Specifications
{
    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        private readonly Expression<Func<TEntity, bool>> originalCriteria;

        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {
            Ensure.Argument.NotNull(originalSpecification, nameof(originalSpecification));
            originalCriteria = originalSpecification.SatisfiedBy();
        }

        public NotSpecification(Expression<Func<TEntity, bool>> originalCriteria)
        {
            this.originalCriteria = originalCriteria ?? throw new ArgumentNullException(nameof(originalCriteria)); ;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(originalCriteria.Body), originalCriteria.Parameters.Single());
        }
    }
}
