using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Pagination;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aritter.Domain.Seedwork
{
    public interface IRepository<TEntity> : IRepository where TEntity : class, IEntity
    {
        Task<TEntity> Get(int id);

        Task<TEntity> Get(ISpecification<TEntity> specification);

        Task<ICollection<TEntity>> Find();

        Task<ICollection<TEntity>> Find(ISpecification<TEntity> specification);

        Task<ICollection<TEntity>> Find<TProperty>(Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        Task<ICollection<TEntity>> Find<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        Task<IPaginatedList<TEntity>> Find(IPagination pagination);

        Task<IPaginatedList<TEntity>> Find(ISpecification<TEntity> specification, IPagination pagination);

        Task<bool> Any();

        Task<bool> Any(ISpecification<TEntity> specification);

        Task<bool> Any<TProperty>(Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        Task<bool> Any<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending);

        Task Add(TEntity entity);

        Task Add(IEnumerable<TEntity> entities);

        Task Update(TEntity entity);

        Task Update(ICollection<TEntity> entites);

        Task Remove(TEntity entity);

        Task Remove(IEnumerable<TEntity> entities);

        Task Remove(ISpecification<TEntity> specification);
    }
}
