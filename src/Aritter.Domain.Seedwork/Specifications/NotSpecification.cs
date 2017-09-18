using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specifications
{
    public sealed class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        private readonly Expression<Func<TEntity, bool>> originalCriteria;

        public NotSpecification(ISpecification<TEntity> originalSpecification)
        {
            Check.IsNotNull(originalSpecification, nameof(originalSpecification));
            originalCriteria = originalSpecification.SatisfiedBy();
        }

        public NotSpecification(Expression<Func<TEntity, bool>> originalCriteria)
        {
            Check.IsNotNull(originalCriteria, nameof(originalCriteria));
            this.originalCriteria = originalCriteria;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return Expression.Lambda<Func<TEntity, bool>>(Expression.Not(originalCriteria.Body), originalCriteria.Parameters.Single());
        }
    }
}
