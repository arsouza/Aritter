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
}
