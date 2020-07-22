using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Collections;

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
            return ParseResult(UnitOfWork.Find<TEntity>(id));
        }

        public virtual async Task<TResponse> FindAsync(TKey id)
        {
            TEntity result = await UnitOfWork
                .FindAsync<TEntity>(id);

            return ParseResult(result);
        }

        public virtual ICollection<TResponse> Find()
        {
            return UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .ToList()
                .Select(e => ParseResult(e))
                .ToList();
        }

        public virtual async Task<ICollection<TResponse>> FindAsync()
        {
            List<TEntity> result = await UnitOfWork
                .Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();

            return result
                .Select(e => ParseResult(e))
                .ToList();
        }

        public virtual IPagedCollection<TResponse> Find(IPagination pagination)
        {
            Ensure.Argument.NotNull(pagination, nameof(pagination));

            return UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .PaginateList(pagination)
                .Select(e => ParseResult(e));
        }

        public virtual async Task<IPagedCollection<TResponse>> FindAsync(IPagination pagination)
        {
            Ensure.Argument.NotNull(pagination, nameof(pagination));

            IPagedCollection<TEntity> result = await UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .PaginateListAsync(pagination);

            return result
                .Select(e => ParseResult(e));
        }

        protected abstract TResponse ParseResult(TEntity obj);
    }
}
