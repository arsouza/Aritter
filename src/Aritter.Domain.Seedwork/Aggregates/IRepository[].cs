using Aritter.Domain.Seedwork.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Aggregates
{
    public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity
    {
        #region Methods

        void Remove(int id);

        void Remove(ISpecification<TEntity> specification);

        IQueryable<TEntity> Find();

        IQueryable<TEntity> Find(ISpecification<TEntity> specification);

        IQueryable<TEntity> Find(ISpecification<TEntity> specification, int index, int size, out int total);

        TEntity Get(int id);

        TEntity Get(ISpecification<TEntity> specification);

        void Add(IEnumerable<TEntity> entities);

        void Add(TEntity entity);

        void Update(ISpecification<TEntity> specification, Expression<Func<TEntity, TEntity>> updateExpression);

        #endregion Methods
    }
}
