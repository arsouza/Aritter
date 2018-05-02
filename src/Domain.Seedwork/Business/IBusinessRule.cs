namespace Ritter.Domain.Business
{
    public interface IBusinessRule<TEntity>
    {
        void Evaluate(TEntity entity);
    }
}
