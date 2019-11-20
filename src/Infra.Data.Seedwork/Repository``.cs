using Ritter.Domain;

namespace Ritter.Infra.Data
{
    public abstract class Repository<TEntity> : Repository<TEntity, long>, IRepository<TEntity>
        where TEntity : class
    {
        protected Repository(IEFUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
