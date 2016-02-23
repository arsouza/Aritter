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

        void Remove(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Find();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int index, int size, out int total);

        TEntity Get(int id);

        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        void Add(IEnumerable<TEntity> entities);

        void Add(TEntity entity);

        void Update(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression);

        #endregion Methods
    }
}
