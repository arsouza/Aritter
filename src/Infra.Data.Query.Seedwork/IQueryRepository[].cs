using Ritter.Infra.Crosscutting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Query
{
    public interface IQueryRepository<TEntity> : IQueryRepository
        where TEntity : class
    {
        TEntity Get(int id);

        Task<TEntity> GetAsync(int id);

        ICollection<TEntity> Find();

        Task<ICollection<TEntity>> FindAsync();

        IPagedCollection<TEntity> Find(IPagination pagination);

        Task<IPagedCollection<TEntity>> FindAsync(IPagination pagination);
    }
}
