using Ritter.Domain.Seedwork.Specifications;
using Ritter.Infra.Crosscutting.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ritter.Domain.Seedwork
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

        IPaginatedList<TEntity> Find(IPagination pagination);

        Task<IPaginatedList<TEntity>> FindAsync(IPagination pagination);

        IPaginatedList<TEntity> Find(ISpecification<TEntity> specification, IPagination pagination);

        Task<IPaginatedList<TEntity>> FindAsync(ISpecification<TEntity> specification, IPagination pagination);

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
