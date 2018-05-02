using Ritter.Domain.Specifications;
using Ritter.Infra.Crosscutting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ritter.Domain
{
    public interface IRepository<TEntity> : IRepository
        where TEntity : class, IEntity
    {
        TEntity Get(int id);

        Task<TEntity> GetAsync(int id);

        ICollection<TEntity> Find();

        Task<ICollection<TEntity>> FindAsync();

        ICollection<TEntity> Find(ISpecification<TEntity> specification);

        Task<ICollection<TEntity>> FindAsync(ISpecification<TEntity> specification);

        IPagedList<TEntity> Find(IPagination pagination);

        Task<IPagedList<TEntity>> FindAsync(IPagination pagination);

        IPagedList<TEntity> Find(ISpecification<TEntity> specification, IPagination pagination);

        Task<IPagedList<TEntity>> FindAsync(ISpecification<TEntity> specification, IPagination pagination);

        bool Any();

        Task<bool> AnyAsync();

        bool Any(ISpecification<TEntity> specification);

        Task<bool> AnyAsync(ISpecification<TEntity> specification);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        Task AddAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        Task UpdateAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        Task RemoveAsync(TEntity entity);

        void Remove(IEnumerable<TEntity> entities);

        Task RemoveAsync(IEnumerable<TEntity> entities);

        void Remove(ISpecification<TEntity> specification);

        Task RemoveAsync(ISpecification<TEntity> specification);
    }
}
