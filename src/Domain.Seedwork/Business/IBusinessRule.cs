namespace Ritter.Domain.Seedwork.Business
{
    public interface IBusinessRule<TEntity>
    {
        void Evaluate(TEntity entity);
    }
}
