using System.Collections.Generic;
using System.Threading.Tasks;
using Ritter.Infra.Crosscutting.Collections;

namespace Ritter.Infra.Data.Query
{
    public interface IQueryRepository<TEntity, TResponse, TKey> : IQueryRepository
       where TResponse : class
       where TEntity : class
    {
        TResponse Find(TKey id);

        Task<TResponse> FindAsync(TKey id);

        ICollection<TResponse> Find();

        Task<ICollection<TResponse>> FindAsync();

        IPagedCollection<TResponse> Find(IPagination pagination);

        Task<IPagedCollection<TResponse>> FindAsync(IPagination pagination);
    }
}
