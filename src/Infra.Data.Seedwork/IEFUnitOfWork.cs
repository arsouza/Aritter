using Ritter.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ritter.Infra.Data
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
