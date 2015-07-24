using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Aritter.Domain.UnitOfWork
{
	public interface IUnitOfWork
	{
		DbContextConfiguration Configuration { get; }
		int SaveChanges();
		DbEntityEntry Entry(object entity);
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		DbSet Set(Type entityType);
	}
}