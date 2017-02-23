using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork
{
    public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity
    {
        #region Methods

        bool Any();
        bool Any(ISpecification<TEntity> specification);

        ICollection<TEntity> Find(ISpecification<TEntity> specification);

        ICollection<TEntity> Find<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        ICollection<TEntity> GetAll();

        PagedList<TEntity> Find(int index, int size);

        PagedList<TEntity> Find(ISpecification<TEntity> specification, int index, int size);

        PagedList<TEntity> Find<TProperty>(int index, int size, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        PagedList<TEntity> Find<TProperty>(ISpecification<TEntity> specification, int index, int size, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        TEntity Get(int id);

        TEntity Get(ISpecification<TEntity> specification);

        void Save(IEnumerable<TEntity> entities);

        void Save(TEntity entity);

        void Remove(TEntity entity);

        void Remove(IEnumerable<TEntity> entities);

        void Remove(ISpecification<TEntity> specification);

        #endregion Methods
    }
}