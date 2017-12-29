using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Ritter.Domain.Seedwork;
using System.Threading.Tasks;

namespace Ritter.Infra.Data.Seedwork
{
    public interface IQueryableUnitOfWork : IUnitOfWork
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
