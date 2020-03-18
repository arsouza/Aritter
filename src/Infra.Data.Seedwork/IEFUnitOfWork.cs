using Microsoft.EntityFrameworkCore;
using Ritter.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Ritter.Infra.Data
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
    }
}
