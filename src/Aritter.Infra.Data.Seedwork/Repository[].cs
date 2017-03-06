using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Pagination;
using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aritter.Infra.Cosscutting.Extensions;

namespace Aritter.Infra.Data.Seedwork
{
	public abstract class Repository<TEntity> : Repository, IRepository<TEntity>
		where TEntity : class, IEntity
	{
		public new IQueryableUnitOfWork UnitOfWork { get; private set; }

		protected Repository(IQueryableUnitOfWork unitOfWork)
			: base(unitOfWork)
		{
			Check.IsNotNull(unitOfWork, nameof(unitOfWork));

			UnitOfWork = unitOfWork;
		}

		public virtual TEntity Get(int id)
		{
			return UnitOfWork
			   .Set<TEntity>()
			   .AsNoTracking()
			   .FirstOrDefault(p => p.Id == id);
		}

		public virtual TEntity Get(ISpecification<TEntity> specification)
		{
			Check.IsNotNull(specification, nameof(specification));

			return UnitOfWork
				.Set<TEntity>()
				.AsNoTracking()
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
			Check.IsNotNull(specification, nameof(specification));

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
			Check.IsNotNull(specification, nameof(specification));

			var query = FindInternal(specification);

			return query
				.ToList();
		}

		public ICollection<TEntity> Find<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
		{
			Check.IsNotNull(specification, nameof(specification));
			Check.IsNotNull(orderByExpression, nameof(orderByExpression));

			var query = FindInternal(specification);

			if (orderByExpression != null)
			{
				query = ascending
					? query.OrderBy(orderByExpression)
					: query.OrderByDescending(orderByExpression);
			}

			return query.ToList();
		}

		public virtual IPaginatedList<TEntity> Find(IPagination pagination)
		{
			return Find(new DirectSpecification<TEntity>(t => true), pagination);
		}

		public virtual IPaginatedList<TEntity> Find(ISpecification<TEntity> specification, IPagination pagination)
		{
			Check.IsNotNull(specification, nameof(specification));

			var query = FindInternal(specification);

			var totalCount = query.Count();

			return query.PaginateList(pagination);
		}

		public IPaginatedList<TEntity> Find<TProperty>(IPagination pagination, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
		{
			Check.IsNotNull(orderByExpression, nameof(orderByExpression));

			return Find(new DirectSpecification<TEntity>(t => true), pagination, orderByExpression, ascending);
		}

		public IPaginatedList<TEntity> Find<TProperty>(ISpecification<TEntity> specification, IPagination pagination, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
		{
			Check.IsNotNull(orderByExpression, nameof(orderByExpression));

			var query = FindInternal(specification);

			if (orderByExpression != null)
			{
				query = ascending
					? query.OrderBy(orderByExpression)
					: query.OrderByDescending(orderByExpression);
			}

			return query.PaginateList(pagination);
		}

		public virtual void Save(TEntity entity)
		{
			SaveInternal(entity);
			((DbContext)UnitOfWork).SaveChanges();
		}

		public virtual void Save(IEnumerable<TEntity> entities)
		{
			Check.IsNotNull(entities, nameof(entities));

			foreach (var entity in entities)
			{
				SaveInternal(entity);
			}

			((DbContext)UnitOfWork).SaveChanges();
		}

		public void Remove(TEntity entity)
		{
			if (entity != null)
			{
				UnitOfWork.Attach(entity);
				UnitOfWork.Set<TEntity>().Remove(entity);
			}

			((DbContext)UnitOfWork).SaveChanges();
		}

		public void Remove(IEnumerable<TEntity> entities)
		{
			if (entities != null)
			{
				UnitOfWork.Attach(entities);
				UnitOfWork.Set<TEntity>().RemoveRange(entities);
			}

			((DbContext)UnitOfWork).SaveChanges();
		}

		public virtual void Remove(ISpecification<TEntity> specification)
		{
			Check.IsNotNull(specification, nameof(specification));

			var entities = UnitOfWork
				.Set<TEntity>()
				.Where(specification.SatisfiedBy())
				.ToList();

			UnitOfWork
				.Set<TEntity>()
				.RemoveRange(entities);

			((DbContext)UnitOfWork).SaveChanges();
		}

		private IQueryable<TEntity> FindInternal(ISpecification<TEntity> specification)
		{
			Check.IsNotNull(specification, nameof(specification));

			return UnitOfWork
				.Set<TEntity>()
				.AsNoTracking()
				.Where(specification.SatisfiedBy());
		}

		private void SaveInternal(TEntity entity)
		{
			Check.IsNotNull(entity, nameof(entity));

			if (UnitOfWork.Set<TEntity>().Any(p => p.Id == entity.Id))
			{
				UnitOfWork.Set<TEntity>().Update(entity);
			}
			else
			{
				UnitOfWork.Set<TEntity>().Add(entity);
			}
		}
	}
}