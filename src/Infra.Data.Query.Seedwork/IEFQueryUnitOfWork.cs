using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Query
{
    public interface IEFQueryUnitOfWork : IQueryUnitOfWork
    {
        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        Task<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
