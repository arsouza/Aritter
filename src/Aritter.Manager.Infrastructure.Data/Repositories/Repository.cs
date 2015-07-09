using Aritter.Manager.Domain;
using Aritter.Manager.Domain.UnitOfWork;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Aritter.Manager.Infrastructure.Data.Repositories
{
	public class Repository : IRepository
	{
		#region Fields

		private readonly IUnitOfWork unitOfWork;

		#endregion Fields

		#region Constructors

		public Repository(IUnitOfWork unitOfWork)
		{
			if (unitOfWork == null)
				throw new ArgumentNullException("unitOfWork");

			this.unitOfWork = unitOfWork;
		}

		#endregion Constructors

		#region Methods

		public virtual int Count<TEntity>() where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(p => p.IsActive)
				.Count();
		}

		public virtual int Count<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(predicate)
				.Where(p => p.IsActive)
				.Count();
		}

		public virtual bool Any<TEntity>() where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(p => p.IsActive)
				.Any();
		}

		public virtual bool Any<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(predicate)
				.Where(p => p.IsActive)
				.Any();
		}

		public virtual void Remove<TEntity>(int id) where TEntity : class, IEntity
		{
			if (id == 0)
				throw new ArgumentNullException("id");

			var entity = unitOfWork
				.Set<TEntity>()
				.Find(id);

			entity.IsActive = false;
		}

		public virtual void Remove<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
		{
			var entities = unitOfWork
				.Set<TEntity>()
				.Where(predicate)
				.ToList();

			foreach (var entity in entities)
			{
				entity.IsActive = false;
			}
		}

		public virtual IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(predicate)
				.Where(p => p.IsActive);
		}

		public virtual IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate, int index, int size, out int total) where TEntity : class, IEntity
		{
			var entities = unitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(predicate)
				.Where(p => p.IsActive);

			var skipCount = index * size;
			entities = skipCount == 0 ? entities.Take(size) : entities.Skip(skipCount).Take(size);
			total = entities.Count();

			return entities;
		}

		public virtual TEntity Get<TEntity>(int id) where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.Find(id);
		}

		public virtual TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.FirstOrDefault(predicate);
		}

		public virtual IQueryable<TEntity> All<TEntity>() where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(p => p.IsActive);
		}

		public virtual void Add<TEntity>(TEntity entity) where TEntity : class, IEntity
		{
			DisableAutoDetectChanges();

			if (entity == null)
				throw new ArgumentNullException("entity");

			unitOfWork.Set<TEntity>().Add(entity);
		}

		public virtual void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
		{
			DisableAutoDetectChanges();

			if (entities == null)
				throw new ArgumentNullException("entities");

			var dbContext = unitOfWork as DbContext;

			if (dbContext == null)
			{
				throw new InvalidOperationException("Invalid instance of IUnitOfWork.");
			}

			dbContext.BulkInsert<TEntity>(entities);
		}

		public virtual void Update<TEntity>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : class, IEntity
		{
			DisableAutoDetectChanges();
			unitOfWork.Set<TEntity>().Where(filterExpression).Update(updateExpression);
		}

		public int SaveChanges()
		{
			EnableAutoDetectChanges();
			return unitOfWork.SaveChanges();
		}

		public void EnableLazyLoad()
		{
			unitOfWork.Configuration.LazyLoadingEnabled = true;
			unitOfWork.Configuration.ProxyCreationEnabled = true;
		}

		public void DisableLazyLoad()
		{
			unitOfWork.Configuration.LazyLoadingEnabled = false;
			unitOfWork.Configuration.ProxyCreationEnabled = false;
		}

		private void EnableAutoDetectChanges()
		{
			unitOfWork.Configuration.AutoDetectChangesEnabled = true;
		}

		private void DisableAutoDetectChanges()
		{
			unitOfWork.Configuration.AutoDetectChangesEnabled = false;
		}

		#endregion Methods
	}
}