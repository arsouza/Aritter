namespace Ritter.Infra.Data.Query
{
    public abstract class QueryRepository<TEntity, TResponse> : QueryRepository<TEntity, TResponse, long>, IQueryRepository<TEntity, TResponse>
        where TEntity : class
        where TResponse : class
    {
        protected QueryRepository(IEFQueryUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
