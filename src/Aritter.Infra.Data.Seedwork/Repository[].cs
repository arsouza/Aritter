using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Adapter;
using Aritter.Infra.Crosscutting.Collections;
using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Extensions;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Infra.Data.Seedwork
{
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Fields

        protected readonly ITypeAdapter typeAdapter;

        #endregion

        #region Constructors

        protected Repository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            typeAdapter = TypeAdapterFactory.CreateAdapter();
        }

        #endregion Constructors

        #region Methods

        public virtual TEntity Get(int id)
        {
            return ((IQueryableUnitOfWork)UnitOfWork)
                .Set<TEntity>()
                .Find(id);
        }

        public virtual TEntity Get(ISpecification<TEntity> specification)
        {
            ThrowHelper.ThrowArgumentNullException(specification, nameof(specification));

            return ((IQueryableUnitOfWork)UnitOfWork)
                .Set<TEntity>()
                .FirstOrDefault(specification.SatisfiedBy());
        }

        public virtual bool Any()
        {
            return ((IQueryableUnitOfWork)UnitOfWork)
                .Set<TEntity>()
                .AsNoTracking()
                .Any();
        }

        public virtual bool Any(ISpecification<TEntity> specification)
        {
            ThrowHelper.ThrowArgumentNullException(specification, nameof(specification));

            return ((IQueryableUnitOfWork)UnitOfWork)
                .Set<TEntity>()
                .AsNoTracking()
                .Any(specification.SatisfiedBy());
        }

        public virtual ICollection<TEntity> GetAll()
        {
            return ((IQueryableUnitOfWork)UnitOfWork)
                .Set<TEntity>()
                .AsNoTracking()
                .ToList();
        }

        public virtual ICollection<TEntity> Find(ISpecification<TEntity> specification)
        {
            ThrowHelper.ThrowArgumentNullException(specification, nameof(specification));

            var query = FindInternal(specification);

            return query
                .ToList();
        }

        public ICollection<TEntity> Find<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            ThrowHelper.ThrowArgumentNullException(specification, nameof(specification));
            ThrowHelper.ThrowArgumentNullException(orderByExpression, nameof(orderByExpression));

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
            ThrowHelper.ThrowArgumentNullException(specification, nameof(specification));

            var query = FindInternal(specification, index, size);

            var totalCount = query.Count();

            return query
                .ToPaginatedList(index, size, totalCount);
        }

        public PaginatedList<TEntity> Find<TProperty>(int index, int size, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            ThrowHelper.ThrowArgumentNullException(orderByExpression, nameof(orderByExpression));

            return Find(new DirectSpecification<TEntity>(t => true), index, size, orderByExpression, ascending);
        }

        public PaginatedList<TEntity> Find<TProperty>(ISpecification<TEntity> specification, int index, int size, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            ThrowHelper.ThrowArgumentNullException(orderByExpression, nameof(orderByExpression));

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
            ThrowHelper.ThrowArgumentNullException(entity, nameof(entity));

            ((IQueryableUnitOfWork)UnitOfWork).Set<TEntity>().Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            var dbContext = (DbContext)UnitOfWork;
            dbContext.BulkInsert(entities);
        }

        public virtual void Update(ISpecification<TEntity> specification, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            ThrowHelper.ThrowArgumentNullException(updateExpression, nameof(updateExpression));

            ((IQueryableUnitOfWork)UnitOfWork).Set<TEntity>().Where(specification.SatisfiedBy()).Update(updateExpression);
        }

        public virtual void Remove(int id)
        {
            var unitOfWork = (IQueryableUnitOfWork)UnitOfWork;

            var entity = unitOfWork
                .Set<TEntity>()
                .Find(id);

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
            ThrowHelper.ThrowArgumentNullException(specification, nameof(specification));

            ((IQueryableUnitOfWork)UnitOfWork).Set<TEntity>().Where(specification.SatisfiedBy()).Delete();
        }

        private IQueryable<TEntity> FindInternal(ISpecification<TEntity> specification)
        {
            ThrowHelper.ThrowArgumentNullException(specification, nameof(specification));

            return ((IQueryableUnitOfWork)UnitOfWork)
                .Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy());
        }

        private IQueryable<TEntity> FindInternal(ISpecification<TEntity> specification, int index, int size)
        {
            var skipCount = index * size;

            var entities = ((IQueryableUnitOfWork)UnitOfWork)
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