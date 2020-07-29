namespace Ritter.Infra.Data.Query
{
    public interface IQueryRepository<TEntity, TResponse> : IQueryRepository<TEntity, TResponse, long>
        where TResponse : class
        where TEntity : class
    {
    }
}
