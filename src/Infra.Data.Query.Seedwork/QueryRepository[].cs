using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Crosscutting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Query
{
    public abstract class QueryRepository<TEntity> : QueryRepository, IQueryRepository<TEntity>
        where TEntity : class
    {
        public new IEFQueryUnitOfWork UnitOfWork { get; private set; }

        protected QueryRepository(IEFQueryUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public TEntity Get(int id)
            => UnitOfWork.Find<TEntity>(id);

        public async Task<TEntity> GetAsync(int id)
            => await UnitOfWork.FindAsync<TEntity>(id);

        public ICollection<TEntity> Find()
            => UnitOfWork.Set<TEntity>().AsNoTracking().ToList();

        public async Task<ICollection<TEntity>> FindAsync()
            => await UnitOfWork.Set<TEntity>().AsNoTracking().ToListAsync();

        public IPagedCollection<TEntity> Find(IPagination pagination)
        {
            Ensure.Argument.NotNull(pagination, nameof(pagination));

            return UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .PaginateList(pagination);
        }

        public async Task<IPagedCollection<TEntity>> FindAsync(IPagination pagination)
        {
            Ensure.Argument.NotNull(pagination, nameof(pagination));

            return await UnitOfWork.Set<TEntity>()
                .AsNoTracking()
                .PaginateListAsync(pagination);
        }
    }
}
