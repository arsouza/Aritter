using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Collections;
using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Infra.Data.Seedwork
{
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Properties

        public new IQueryableUnitOfWork UnitOfWork { get; private set; }

        #endregion

        #region Constructors

        protected Repository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region Methods

        public virtual TEntity Get(int id)
        {
            return UnitOfWork
                .Set<TEntity>()
               .FirstOrDefault(p => p.Id == id);
        }

        public virtual TEntity Get(ISpecification<TEntity> specification)
        {
            Guard.IsNotNull(specification, nameof(specification));

            return UnitOfWork
                .Set<TEntity>()
                .Where(specification.SatisfiedBy())
                .FirstOrDefault();
        }

        public virtual bool Any()
        {
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Any();
        }

        public virtual bool Any(ISpecification<TEntity> specification)
        {
            Guard.IsNotNull(specification, nameof(specification));

            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Any(specification.SatisfiedBy());
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .ToList();
        }

        public virtual ICollection<TEntity> Find(ISpecification<TEntity> specification)
        {
            Guard.IsNotNull(specification, nameof(specification));

            var query = FindInternal(specification);

            return query
                .ToList();
        }

        public ICollection<TEntity> Find<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            Guard.IsNotNull(specification, nameof(specification));
            Guard.IsNotNull(orderByExpression, nameof(orderByExpression));

            var query = FindInternal(specification);

            if (orderByExpression != null)
            {
                query = ascending
                    ? query.OrderBy(orderByExpression)
                    : query.OrderByDescending(orderByExpression);
            }

            return query.ToList();
        }

        public virtual PaginatedList<TEntity> Find(int index, int size)
        {
            return Find(new DirectSpecification<TEntity>(t => true), index, size);
        }

        public virtual PaginatedList<TEntity> Find(ISpecification<TEntity> specification, int index, int size)
        {
            Guard.IsNotNull(specification, nameof(specification));

            var query = FindInternal(specification, index, size);

            var totalCount = query.Count();

            return query
                .ToPaginatedList(index, size, totalCount);
        }

        public PaginatedList<TEntity> Find<TProperty>(int index, int size, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            Guard.IsNotNull(orderByExpression, nameof(orderByExpression));

            return Find(new DirectSpecification<TEntity>(t => true), index, size, orderByExpression, ascending);
        }

        public PaginatedList<TEntity> Find<TProperty>(ISpecification<TEntity> specification, int index, int size, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            Guard.IsNotNull(orderByExpression, nameof(orderByExpression));

            var query = FindInternal(specification, index, size);

            if (orderByExpression != null)
            {
                query = ascending
                    ? query.OrderBy(orderByExpression)
                    : query.OrderByDescending(orderByExpression);
            }

            var totalCount = query.Count();

            return query
                .ToPaginatedList(index, size, totalCount);
        }

        public virtual void Add(TEntity entity)
        {
            Guard.IsNotNull(entity, nameof(entity));

            UnitOfWork
                .Set<TEntity>()
                .Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            Guard.IsNotNull(entities, nameof(entities));
            UnitOfWork
                .Set<TEntity>()
                .AddRange(entities);
        }

        public virtual void Update(params TEntity[] entities)
        {
            Guard.IsNotNull(entities, nameof(entities));

            UnitOfWork
                .Set<TEntity>()
                .UpdateRange(entities);
        }

        public virtual void Remove(int id)
        {
            var unitOfWork = UnitOfWork;
            var entity = Get(id);

            unitOfWork
                .Set<TEntity>()
                .Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            Remove(entity.Id);
        }

        public virtual void Remove(ISpecification<TEntity> specification)
        {
            Guard.IsNotNull(specification, nameof(specification));

            var entities = UnitOfWork
                .Set<TEntity>()
                .Where(specification.SatisfiedBy())
                .ToArray();

            UnitOfWork
                .Set<TEntity>()
                .RemoveRange(entities);
        }

        private IQueryable<TEntity> FindInternal(ISpecification<TEntity> specification)
        {
            Guard.IsNotNull(specification, nameof(specification));

            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy());
        }

        private IQueryable<TEntity> FindInternal(ISpecification<TEntity> specification, int index, int size)
        {
            var skipCount = index * size;

            var entities = UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy());

            return entities
                .Skip(skipCount)
                .Take(size);
        }

        #endregion Methods
    }
}