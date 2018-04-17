using Microsoft.EntityFrameworkCore;
using Ritter.Domain.Seedwork;
using Ritter.Domain.Seedwork.Specifications;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Extensions;
using Ritter.Infra.Crosscutting.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Seedwork
{
    public abstract class Repository<TEntity> : Repository, IRepository<TEntity> where TEntity : class, IEntity
    {
        public new IQueryableUnitOfWork UnitOfWork { get; private set; }

        protected Repository(IQueryableUnitOfWork unitOfWork) : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
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
            Ensure.Argument.NotNull(specification, nameof(specification));
            return FindSpecific(specification).ToList();
        }

        public async Task<ICollection<TEntity>> FindAsync(ISpecification<TEntity> specification)
        {
            Ensure.Argument.NotNull(specification, nameof(specification));
            return await FindSpecific(specification).ToListAsync();
        }

        public IPagedList<TEntity> Find(IPagination pagination)
        {
            return Find(new TrueSpecification<TEntity>(), pagination);
        }

        public async Task<IPagedList<TEntity>> FindAsync(IPagination pagination)
        {
            return await FindAsync(new TrueSpecification<TEntity>(), pagination);
        }

        public IPagedList<TEntity> Find(ISpecification<TEntity> specification, IPagination pagination)
        {
            Ensure.Argument.NotNull(specification, nameof(specification));
            Ensure.Argument.NotNull(pagination, nameof(pagination));

            return FindSpecific(specification).PaginateList(pagination);
        }

        public async Task<IPagedList<TEntity>> FindAsync(ISpecification<TEntity> specification, IPagination pagination)
        {
            Ensure.Argument.NotNull(specification, nameof(specification));
            Ensure.Argument.NotNull(pagination, nameof(pagination));

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
            Ensure.Argument.NotNull(specification, nameof(specification));
            return FindSpecific(specification).Any();
        }

        public virtual async Task<bool> AnyAsync(ISpecification<TEntity> specification)
        {
            Ensure.Argument.NotNull(specification, nameof(specification));
            return await FindSpecific(specification).AnyAsync();
        }

        public virtual void Add(TEntity entity)
        {
            Ensure.Argument.NotNull(entity, nameof(entity));

            UnitOfWork.Set<TEntity>().Add(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            Ensure.Argument.NotNull(entity, nameof(entity));

            await UnitOfWork.Set<TEntity>().AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            Ensure.Argument.NotNull(entities, nameof(entities));

            UnitOfWork.Set<TEntity>().AddRange(entities);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task AddAsync(IEnumerable<TEntity> entities)
        {
            Ensure.Argument.NotNull(entities, nameof(entities));

            await UnitOfWork.Set<TEntity>().AddRangeAsync(entities);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            Ensure.Argument.NotNull(entity, nameof(entity));

            UnitOfWork.Set<TEntity>().Update(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Ensure.Argument.NotNull(entity, nameof(entity));

            UnitOfWork.Set<TEntity>().Update(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            Ensure.Argument.NotNull(entities, nameof(entities));

            UnitOfWork.Set<TEntity>().UpdateRange(entities);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task UpdateAsync(IEnumerable<TEntity> entities)
        {
            Ensure.Argument.NotNull(entities, nameof(entities));

            UnitOfWork.Set<TEntity>().UpdateRange(entities);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Remove(TEntity entity)
        {
            Ensure.Argument.NotNull(entity, nameof(entity));

            UnitOfWork.Set<TEntity>().Remove(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            Ensure.Argument.NotNull(entity, nameof(entity));

            UnitOfWork.Set<TEntity>().Remove(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            Ensure.Argument.NotNull(entities, nameof(entities));

            UnitOfWork.Set<TEntity>().RemoveRange(entities);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            Ensure.Argument.NotNull(entities, nameof(entities));

            UnitOfWork.Set<TEntity>().RemoveRange(entities);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Remove(ISpecification<TEntity> specification)
        {
            Ensure.Argument.NotNull(specification, nameof(specification));

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
            Ensure.Argument.NotNull(specification, nameof(specification));

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
