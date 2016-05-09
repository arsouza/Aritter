using Aritter.Domain.Seedwork.Aggregates;
using Aritter.Domain.Seedwork.Specifications;
using Aritter.Domain.Seedwork.UnitOfWork;
using Aritter.Infra.CrossCutting.Adapter;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Infra.Data.Seedwork.Repositories
{
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Fields

        protected readonly ITypeAdapter typeAdapter;

        #endregion

        #region Constructors

        public Repository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            typeAdapter = TypeAdapterFactory.CreateAdapter();
        }

        #endregion Constructors

        #region Methods

        public virtual TEntity Get(int id)
        {
            return UnitOfWork
                .Set<TEntity>()
                .Find(id);
        }

        public virtual TEntity Get(ISpecification<TEntity> specification)
        {
            return UnitOfWork
                .Set<TEntity>()
                .FirstOrDefault(specification.SatisfiedBy());
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
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Any(specification.SatisfiedBy());
        }

        public virtual IQueryable<TEntity> Find()
        {
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking();
        }

        public virtual IQueryable<TEntity> Find(ISpecification<TEntity> specification)
        {
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy());
        }

        public virtual IQueryable<TEntity> Find(ISpecification<TEntity> specification, int index, int size, out int total)
        {
            var skipCount = index * size;

            var entities = UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy());

            total = entities.Count();

            return entities
                .Skip(skipCount)
                .Take(size);
        }

        public virtual void Add(TEntity entity)
        {
            Contract.Ensures(entity != null);
            UnitOfWork.Set<TEntity>().Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            Contract.Ensures(entities != null);

            var dbContext = (DbContext)UnitOfWork;
            dbContext.BulkInsert(entities);
        }

        public virtual void Update(ISpecification<TEntity> specification, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            UnitOfWork.Set<TEntity>().Where(specification.SatisfiedBy()).Update(updateExpression);
        }

        public virtual void Remove(int id)
        {
            Contract.Ensures(id > 0);

            var entity = UnitOfWork
                .Set<TEntity>()
                .Find(id);

            UnitOfWork
                .Set<TEntity>()
                .Remove(entity);
        }

        public virtual void Remove(ISpecification<TEntity> specification)
        {
            UnitOfWork.Set<TEntity>().Where(specification.SatisfiedBy()).Delete();
        }

        #endregion Methods
    }
}