namespace Ritter.Domain
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
