using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Aritter.Domain
{
	public interface IRepository
	{
		#region Methods

		int Count<TEntity>() where TEntity : class, IEntity;

		Task<int> CountAsync<TEntity>() where TEntity : class, IEntity;

		int Count<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		bool Any<TEntity>() where TEntity : class, IEntity;

		bool Any<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		void Remove<TEntity>(int id) where TEntity : class, IEntity;

		Task RemoveAsync<TEntity>(int id) where TEntity : class, IEntity;

		void Remove<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		Task RemoveAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		Task<IQueryable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate, int index, int size, out int total) where TEntity : class, IEntity;

		Task<IQueryable<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, int index, int size, out int total) where TEntity : class, IEntity;

		TEntity Get<TEntity>(int id) where TEntity : class, IEntity;

		Task<TEntity> GetAsync<TEntity>(int id) where TEntity : class, IEntity;

		TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class, IEntity;

		IQueryable<TEntity> All<TEntity>() where TEntity : class, IEntity;

		void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

		void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

		void Update<TEntity>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression) where TEntity : class, IEntity;

		int SaveChanges();

		#endregion Methods
	}
}