namespace Ritter.Domain
{
    public interface IRepository<TEntity> : IRepository<TEntity, long>
        where TEntity : class
    {
    }
}
