namespace Ritter.Infra.Data.Query
{
    public interface IQueryRepository
    {
        IQueryUnitOfWork UnitOfWork { get; }
    }
}
