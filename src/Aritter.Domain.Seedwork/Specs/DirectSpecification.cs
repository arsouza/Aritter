using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Specs
{
    public class DirectSpecification<TEntity> : Specification<TEntity>
        where TEntity : class, IEntity
    {
        #region Members

        private readonly Expression<Func<TEntity, bool>> matchingCriteria;

        #endregion

        #region Constructor

        public DirectSpecification(Expression<Func<TEntity, bool>> matchingCriteria)
        {
            Check.IsNotNull(matchingCriteria, nameof(matchingCriteria));
            this.matchingCriteria = matchingCriteria;
        }

        #endregion

        #region Override

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return matchingCriteria;
        }

        #endregion
    }
}
