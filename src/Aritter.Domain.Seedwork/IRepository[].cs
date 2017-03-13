using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Pagination;
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

        IPaginatedList<TEntity> Find(IPagination pagination);

        IPaginatedList<TEntity> Find(ISpecification<TEntity> specification, IPagination pagination);

        IPaginatedList<TEntity> Find<TProperty>(IPagination pagination, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        IPaginatedList<TEntity> Find<TProperty>(ISpecification<TEntity> specification, IPagination pagination, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

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