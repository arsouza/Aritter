using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Aritter.Domain.UnitOfWork
{
	public interface IUnitOfWork
	{
		DbContextConfiguration Configuration { get; }
		int SaveChanges();
		Task<int> SaveChangesAsync();
		DbEntityEntry Entry(object entity);
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		DbSet Set(Type entityType);
	}
}