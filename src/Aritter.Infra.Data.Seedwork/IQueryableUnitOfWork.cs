using Aritter.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aritter.Infra.Data.Seedwork
{
	public interface IQueryableUnitOfWork : IUnitOfWork, ISql
	{
		EntityEntry Entry(object entity);
		EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		EntityEntry Attach(object entity);
		EntityEntry<TEntity> Attach<TEntity>(TEntity entity) where TEntity : class;
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
	}
}