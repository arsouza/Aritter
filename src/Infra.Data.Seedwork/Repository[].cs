using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Infra.Crosscutting.Extensions;
using Ritter.Infra.Crosscutting.Pagination;

namespace Ritter.Infra.Data.Seedwork
{
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class, IEntity
    {
        public new IQueryableUnitOfWork UnitOfWork { get; private set; }

        protected Repository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
        }

        public TEntity Get(int id)
        {
            return UnitOfWork
                .Set<TEntity>()
                .FirstOrDefault(p => p.Id == id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await UnitOfWork
                .Set<TEntity>()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public ICollection<TEntity> Find()
        {
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .ToList();
        }

        public async Task<ICollection<TEntity>> FindAsync()
        {
            return await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public ICollection<TEntity> Find(ISpecification<TEntity> specification)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            return FindSpecific(specification).ToList();
        }

        public async Task<ICollection<TEntity>> FindAsync(ISpecification<TEntity> specification)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            return await FindSpecific(specification).ToListAsync();
        }

        public IPaginatedList<TEntity> Find(IPagination pagination)
        {
            return Find(new TrueSpecification<TEntity>(), pagination);
        }

        public async Task<IPaginatedList<TEntity>> FindAsync(IPagination pagination)
        {
            return await FindAsync(new TrueSpecification<TEntity>(), pagination);
        }

        public IPaginatedList<TEntity> Find(ISpecification<TEntity> specification, IPagination pagination)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            if (pagination is null)
                throw new ArgumentNullException(nameof(pagination));

            return FindSpecific(specification).PaginateList(pagination);
        }

        public async Task<IPaginatedList<TEntity>> FindAsync(ISpecification<TEntity> specification, IPagination pagination)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            if (pagination is null)
                throw new ArgumentNullException(nameof(pagination));

            return await FindSpecific(specification).PaginateListAsync(pagination);
        }

        public bool Any()
        {
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .Any();
        }

        public async Task<bool> AnyAsync()
        {
            return await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .AnyAsync();
        }

        public virtual bool Any(ISpecification<TEntity> specification)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            return FindSpecific(specification).Any();
        }

        public virtual async Task<bool> AnyAsync(ISpecification<TEntity> specification)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            return await FindSpecific(specification).AnyAsync();
        }

        public virtual void Add(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            UnitOfWork.Set<TEntity>().Add(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await UnitOfWork.Set<TEntity>().AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            UnitOfWork.Set<TEntity>().AddRange(entities);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task AddAsync(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            await UnitOfWork.Set<TEntity>().AddRangeAsync(entities);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (!UnitOfWork.IsLocal(entity))
                throw new InvalidOperationException(@"The entity is not attached to the context. If you obtained the instance through the ""Find"" methods try changing to ""Get""");

            UnitOfWork.Set<TEntity>().Update(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (!UnitOfWork.IsLocal(entity))
                throw new InvalidOperationException(@"The entity is not attached to the context. If you obtained the instance through the ""Find"" methods try changing to ""Get""");

            UnitOfWork.Set<TEntity>().Update(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            if (entities.Any(entity => !UnitOfWork.IsLocal(entity)))
                throw new InvalidOperationException(@"The entity is not attached to the context. If you obtained the instance through the ""Find"" methods try changing to ""Get""");

            UnitOfWork.Set<TEntity>().UpdateRange(entities);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            if (entities.Any(entity => !UnitOfWork.IsLocal(entity)))
                throw new InvalidOperationException(@"The entity is not attached to the context. If you obtained the instance through the ""Find"" methods try changing to ""Get""");

            UnitOfWork.Set<TEntity>().UpdateRange(entities);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Remove(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            UnitOfWork.Set<TEntity>().Remove(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            UnitOfWork.Set<TEntity>().Remove(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            UnitOfWork.Set<TEntity>().RemoveRange(entities);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            UnitOfWork.Set<TEntity>().RemoveRange(entities);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Remove(ISpecification<TEntity> specification)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            var entities = UnitOfWork
                .Set<TEntity>()
                .Where(specification.SatisfiedBy())
                .ToList();

            UnitOfWork
                .Set<TEntity>()
                .RemoveRange(entities);

            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(ISpecification<TEntity> specification)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));

            var entities = UnitOfWork
                .Set<TEntity>()
                .Where(specification.SatisfiedBy())
                .ToList();

            UnitOfWork
                .Set<TEntity>()
                .RemoveRange(entities);

            await UnitOfWork.SaveChangesAsync();
        }

        private IQueryable<TEntity> FindSpecific(ISpecification<TEntity> specification)
        {
            return UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy());
        }
    }
}