namespace Ritter.Domain.Seedwork.Business
{
    public interface IBusinessRulesEvaluator<TEntity>
    {
        void Evaluate(TEntity entity);
    }
}
