using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Aritter.Domain.Seedwork;

namespace Aritter.Infra.Data.Seedwork
{
    public interface IQueryableUnitOfWork : IUnitOfWork, ISql
    {
        DbContextConfiguration Configuration { get; }
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbSet Set(Type entityType);
        void Attach<TEntity>(TEntity item) where TEntity : class;
        void SetModified<TEntity>(TEntity item) where TEntity : class;
        void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class;
    }
}