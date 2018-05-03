using Microsoft.EntityFrameworkCore;
using Ritter.Domain;
using System.Threading.Tasks;

namespace Ritter.Infra.Data
{
    public interface IQueryableUnitOfWork : IUnitOfWork
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
