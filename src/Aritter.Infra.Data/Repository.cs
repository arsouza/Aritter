using Aritter.Domain;
using Aritter.Domain.UnitOfWork;
using EntityFramework.BulkInsert.Extensions;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aritter.Infra.Data
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
				throw new ArgumentNullException(nameof(unitOfWork));

			this.unitOfWork = unitOfWork;
		}

		#endregion Constructors

		#region Methods

		public virtual IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(predicate);
		}

		public virtual IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate, int index, int size, out int total) where TEntity : class, IEntity
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

		public virtual IQueryable<TEntity> Find<TEntity>() where TEntity : class, IEntity
		{
			return unitOfWork
				.Set<TEntity>()
				.AsNoTracking();
		}

		public virtual void Add<TEntity>(TEntity entity) where TEntity : class, IEntity
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			unitOfWork.Set<TEntity>().Add(entity);
		}

		public virtual void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
		{
			if (entities == null)
				throw new ArgumentNullException(nameof(entities));

			var dbContext = (DbContext)unitOfWork;

			dbContext.BulkInsert(entities);
		}

		public virtual void Update<TEntity>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : class, IEntity
		{
			unitOfWork.Set<TEntity>().Where(filterExpression).Update(updateExpression);
		}

		public virtual void Remove<TEntity>(int id) where TEntity : class, IEntity
		{
			if (id == 0)
				throw new ArgumentNullException(nameof(id));

			var entity = unitOfWork
				.Set<TEntity>()
				.Find(id);

			unitOfWork
				.Set<TEntity>()
				.Remove(entity);
		}

		public virtual void Remove<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity
		{
			unitOfWork.Set<TEntity>().Where(predicate).Delete();
		}

		public int SaveChanges()
		{
			return unitOfWork.SaveChanges();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await unitOfWork.SaveChangesAsync();
		}

		#endregion Methods
	}
}