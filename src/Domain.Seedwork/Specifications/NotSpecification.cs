using Ritter.Infra.Crosscutting;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(originalCriteria.Body), originalCriteria.Parameters.Single());
        }
    }
}
