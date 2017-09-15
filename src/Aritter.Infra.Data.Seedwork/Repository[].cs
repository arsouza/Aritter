using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Extensions;
using Aritter.Infra.Crosscutting.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        public virtual async Task<TEntity> Get(int id)
        {
            return await UnitOfWork
               .Set<TEntity>()
               .AsNoTracking()
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public virtual async Task<TEntity> Get(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));

            return await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy())
                .FirstOrDefaultAsync();
        }

        public virtual async Task<ICollection<TEntity>> Find()
        {
            return await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> Find(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));

            var query = FindInternal(specification);

            return await query.ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> Find<TProperty>(Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            Check.IsNotNull(orderByExpression, nameof(orderByExpression));

            var query = UnitOfWork
                .Set<TEntity>()
                .AsNoTracking();

            if (orderByExpression != null)
            {
                query = ascending
                    ? query.OrderBy(orderByExpression)
                    : query.OrderByDescending(orderByExpression);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<ICollection<TEntity>> Find<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
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

            return await query.ToListAsync();
        }

        public virtual async Task<IPaginatedList<TEntity>> Find(IPagination pagination)
        {
            return await Find(new DirectSpecification<TEntity>(t => true), pagination);
        }

        public virtual async Task<IPaginatedList<TEntity>> Find(ISpecification<TEntity> specification, IPagination pagination)
        {
            Check.IsNotNull(specification, nameof(specification));

            var query = FindInternal(specification);

            var totalCount = query.Count();

            return await query.PaginateListAsync(pagination);
        }

        public virtual async Task<bool> Any()
        {
            return await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .AnyAsync();
        }

        public virtual async Task<bool> Any(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));

            var query = FindInternal(specification);

            return await query.AnyAsync();
        }

        public virtual async Task<bool> Any<TProperty>(Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
        {
            Check.IsNotNull(orderByExpression, nameof(orderByExpression));

            var query = UnitOfWork
                .Set<TEntity>()
                .AsNoTracking();

            if (orderByExpression != null)
            {
                query = ascending
                    ? query.OrderBy(orderByExpression)
                    : query.OrderByDescending(orderByExpression);
            }

            return await query.AnyAsync();
        }

        public virtual async Task<bool> Any<TProperty>(ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> orderByExpression, bool ascending)
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

            return await query.AnyAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await UnitOfWork.Set<TEntity>().AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task Add(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            await UnitOfWork.Set<TEntity>().AddRangeAsync(entities);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (UnitOfWork.Set<TEntity>().Local.All(e => e != entity))
            {
                throw new InvalidOperationException(@"The entity is not attached to the context. If you obtained the instance through the ""Find"", ""FindOne"" or ""GetAll"" methods try changing to ""Get""");
            }

            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task Update(ICollection<TEntity> entites)
        {
            if (entites is null || !entites.Any())
                throw new ArgumentNullException(nameof(entites));

            entites.ToList().ForEach(entity =>
            {
                if (UnitOfWork.Set<TEntity>().Local.All(e => e != entity))
                {
                    throw new InvalidOperationException(@"The entity is not attached to the context. If you obtained the instance through the ""Find"", ""FindOne"" or ""GetAll"" methods try changing to ""Get""");
                }
            });

            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task Remove(TEntity entity)
        {
            if (entity != null)
            {
                UnitOfWork.Attach(entity);
                UnitOfWork.Set<TEntity>().Remove(entity);
            }

            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task Remove(IEnumerable<TEntity> entities)
        {
            if (entities != null)
            {
                UnitOfWork.Attach(entities);
                UnitOfWork.Set<TEntity>().RemoveRange(entities);
            }

            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task Remove(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));

            var entities = UnitOfWork
                .Set<TEntity>()
                .Where(specification.SatisfiedBy())
                .ToList();

            UnitOfWork
                .Set<TEntity>()
                .RemoveRange(entities);

            await UnitOfWork.SaveChangesAsync();
        }

        private IQueryable<TEntity> FindInternal(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));

            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy());
        }
    }
}
