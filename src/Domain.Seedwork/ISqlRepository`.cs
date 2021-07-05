namespace Ritter.Domain
{
    public interface ISqlRepository<TEntity> : ISqlRepository<TEntity, long>
        where TEntity : class
    {
    }
}
