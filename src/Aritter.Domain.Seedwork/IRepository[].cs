using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork
{
    public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity
    {
        #region Methods

        void Remove(int id);

        void Remove(TEntity entity);

        void Remove(ISpecification<TEntity> specification);

        bool Any();

        bool Any(ISpecification<TEntity> specification);

        ICollection<TEntity> GetAll();

        ICollection<TEntity> Find(ISpecification<TEntity> specification);

        ICollection<TEntity> Find<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        PaginatedList<TEntity> Find(int index, int size);

        PaginatedList<TEntity> Find<TProperty>(int index, int size, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        PaginatedList<TEntity> Find(ISpecification<TEntity> specification, int index, int size);

        PaginatedList<TEntity> Find<TProperty>(ISpecification<TEntity> specification, int index, int size, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        TEntity Get(int id);

        TEntity Get(ISpecification<TEntity> specification);

        void Add(IEnumerable<TEntity> entities);

        void Add(TEntity entity);

        void Update(ISpecification<TEntity> specification, Expression<Func<TEntity, TEntity>> updateExpression);

        #endregion Methods
    }
}