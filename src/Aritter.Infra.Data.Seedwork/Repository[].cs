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

        public TEntity Get(int id)
        {
            return UnitOfWork.Set<TEntity>().FirstOrDefault(p => p.Id == id);
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await UnitOfWork.Set<TEntity>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public TEntity Get(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));
            return UnitOfWork.Set<TEntity>().FirstOrDefault(specification.SatisfiedBy());
        }

        public async Task<TEntity> GetAsync(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));
            return await UnitOfWork.Set<TEntity>().FirstOrDefaultAsync(specification.SatisfiedBy());
        }

        public TEntity FindOne(int id)
        {
            return UnitOfWork.Set<TEntity>().AsNoTracking().FirstOrDefault(p => p.Id == id);
        }

        public async Task<TEntity> FindOneAsync(int id)
        {
            return await UnitOfWork.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public TEntity FindOne(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));
            return UnitOfWork.Set<TEntity>().AsNoTracking().FirstOrDefault(specification.SatisfiedBy());
        }

        public async Task<TEntity> FindOneAsync(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));
            return await UnitOfWork.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(specification.SatisfiedBy());
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
            Check.IsNotNull(specification, nameof(specification));
            return FindSpecific(specification).ToList();
        }

        public async Task<ICollection<TEntity>> FindAsync(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));
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
            Check.IsNotNull(specification, nameof(specification));
            return FindSpecific(specification).PaginateList(pagination);
        }

        public async Task<IPaginatedList<TEntity>> FindAsync(ISpecification<TEntity> specification, IPagination pagination)
        {
            Check.IsNotNull(specification, nameof(specification));
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
            Check.IsNotNull(specification, nameof(specification));
            return FindSpecific(specification).Any();
        }

        public virtual async Task<bool> AnyAsync(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));
            return await FindSpecific(specification).AnyAsync();
        }

        public virtual void Add(TEntity entity)
        {
            Check.IsNotNull(entity, nameof(entity));
            UnitOfWork.Set<TEntity>().Add(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            Check.IsNotNull(entity, nameof(entity));
            await UnitOfWork.Set<TEntity>().AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Add(IEnumerable<TEntity> entities)
        {
            Check.IsNotNull(entities, nameof(entities));
            UnitOfWork.Set<TEntity>().AddRange(entities);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task AddAsync(IEnumerable<TEntity> entities)
        {
            Check.IsNotNull(entities, nameof(entities));
            await UnitOfWork.Set<TEntity>().AddRangeAsync(entities);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Update(TEntity entity)
        {
            Check.IsNotNull(entity, nameof(entity));
            Check.Against<InvalidOperationException>(UnitOfWork.Set<TEntity>().Local.All(e => e != entity), @"The entity is not attached to the context. If you obtained the instance through the ""Find"" or ""FindOne"" methods try changing to ""Get""");
            UnitOfWork.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Check.IsNotNull(entity, nameof(entity));
            Check.Against<InvalidOperationException>(UnitOfWork.Set<TEntity>().Local.All(e => e != entity), @"The entity is not attached to the context. If you obtained the instance through the ""Find"" or ""FindOne"" methods try changing to ""Get""");
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Update(ICollection<TEntity> entities)
        {
            Check.IsNotNull(entities, nameof(entities));
            entities.ForEach(entity =>
            {
                Check.Against<InvalidOperationException>(UnitOfWork.Set<TEntity>().Local.All(e => e != entity), @"The entity is not attached to the context. If you obtained the instance through the ""Find"" or ""FindOne"" methods try changing to ""Get""");
            });
            UnitOfWork.SaveChanges();
        }

        public virtual async Task UpdateAsync(ICollection<TEntity> entities)
        {
            Check.IsNotNull(entities, nameof(entities));
            entities.ForEach(entity =>
            {
                Check.Against<InvalidOperationException>(UnitOfWork.Set<TEntity>().Local.All(e => e != entity), @"The entity is not attached to the context. If you obtained the instance through the ""Find"" or ""FindOne"" methods try changing to ""Get""");
            });
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Remove(TEntity entity)
        {
            Check.IsNotNull(entity, nameof(entity));
            UnitOfWork.Set<TEntity>().Remove(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            Check.IsNotNull(entity, nameof(entity));
            UnitOfWork.Set<TEntity>().Remove(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            Check.IsNotNull(entities, nameof(entities));
            UnitOfWork.Set<TEntity>().RemoveRange(entities);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(IEnumerable<TEntity> entities)
        {
            Check.IsNotNull(entities, nameof(entities));
            UnitOfWork.Set<TEntity>().RemoveRange(entities);
            await UnitOfWork.SaveChangesAsync();
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

            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(ISpecification<TEntity> specification)
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

        private IQueryable<TEntity> FindSpecific(ISpecification<TEntity> specification)
        {
            Check.IsNotNull(specification, nameof(specification));

            return UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .Where(specification.SatisfiedBy());
        }
    }
}
