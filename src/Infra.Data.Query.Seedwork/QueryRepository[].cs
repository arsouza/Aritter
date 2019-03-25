using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Crosscutting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Query
{
    public abstract class QueryRepository<TEntity, TResponse, TKey> : QueryRepository, IQueryRepository<TEntity, TResponse, TKey>
        where TEntity : class
        where TResponse : class
        where TKey : struct
    {
        public new IEFQueryUnitOfWork UnitOfWork { get; private set; }

        protected QueryRepository(IEFQueryUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual TResponse Find(TKey id)
        {
            return CastResult(UnitOfWork.Find<TEntity>(id));
        }

        public virtual async Task<TResponse> FindAsync(TKey id)
        {
            var result = await UnitOfWork
                .FindAsync<TEntity>(id);

            return CastResult(result);
        }

        public virtual ICollection<TResponse> Find()
        {
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .ToList()
                .Select(e => CastResult(e))
                .ToList();
        }

        public virtual async Task<ICollection<TResponse>> FindAsync()
        {
            var result = await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();

            return result
                .Select(e => CastResult(e))
                .ToList();
        }

        public virtual IPagedCollection<TResponse> Find(IPagination pagination)
        {
            Ensure.Argument.NotNull(pagination, nameof(pagination));

            return UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .PaginateList(pagination)
                .Select(e => CastResult(e));
        }

        public virtual async Task<IPagedCollection<TResponse>> FindAsync(IPagination pagination)
        {
            Ensure.Argument.NotNull(pagination, nameof(pagination));

            var result = await UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .PaginateListAsync(pagination);

            return result
                .Select(e => CastResult(e));
        }

        protected abstract TResponse CastResult(TEntity obj);
    }

    public abstract class QueryRepository<TEntity, TResponse> : QueryRepository<TEntity, TResponse, long>, IQueryRepository<TEntity, TResponse>
        where TEntity : class
        where TResponse : class
    {
        protected QueryRepository(IEFQueryUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
