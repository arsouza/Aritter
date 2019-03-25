using Ritter.Infra.Crosscutting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Query
{
    public interface IQueryRepository<TEntity, TResponse, TKey> : IQueryRepository
       where TResponse : class
       where TEntity : class
       where TKey : struct
    {
        TResponse Find(TKey id);

        Task<TResponse> FindAsync(TKey id);
    }

    public interface IQueryRepository<TEntity, TResponse> : IQueryRepository<TEntity, TResponse, long>
       where TResponse : class
       where TEntity : class
    {
        ICollection<TResponse> Find();

        Task<ICollection<TResponse>> FindAsync();

        IPagedCollection<TResponse> Find(IPagination pagination);

        Task<IPagedCollection<TResponse>> FindAsync(IPagination pagination);
    }
}
