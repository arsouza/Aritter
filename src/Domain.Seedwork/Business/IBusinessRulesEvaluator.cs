namespace Ritter.Domain.Business
{
    public interface IBusinessRulesEvaluator<TEntity>
    {
        void Evaluate(TEntity entity);
    }
}
