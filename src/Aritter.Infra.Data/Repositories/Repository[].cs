using Aritter.Domain.Contracts;
using Aritter.Domain.UnitOfWork;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Constructors

        public Repository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion Constructors

        #region Methods

        public virtual TEntity Get(int id)
        {
            return unitOfWork
                .Set<TEntity>()
                .Find(id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return unitOfWork
                .Set<TEntity>()
                .FirstOrDefault(predicate);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return unitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(predicate);
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, int index, int size, out int total)
        {
            var skipCount = index * size;

            var entities = unitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(predicate)
                .Skip(skipCount)
                .Take(size);

            total = entities.Count();

            return entities;
        }

        public virtual IQueryable<TEntity> Find()
        {
            return unitOfWork
                .Set<TEntity>()
                .AsNoTracking();
        }

        public virtual void Add(TEntity entity)
        {
            Contract.Ensures(entity != null);
            unitOfWork.Set<TEntity>().Add(entity);
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            Contract.Ensures(entities != null);

            var dbContext = (DbContext)unitOfWork;
            dbContext.BulkInsert(entities);
        }

        public virtual void Update(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            unitOfWork.Set<TEntity>().Where(filterExpression).Update(updateExpression);
        }

        public virtual void Remove(int id)
        {
            Contract.Ensures(id > 0);

            var entity = unitOfWork
                .Set<TEntity>()
                .Find(id);

            unitOfWork
                .Set<TEntity>()
                .Remove(entity);
        }

        public virtual void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            unitOfWork.Set<TEntity>().Where(predicate).Delete();
        }

        #endregion Methods
    }
}