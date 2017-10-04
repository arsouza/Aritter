namespace Ritter.Domain.Seedwork.Rules.Business
{
    public interface IBusinessRulesEvaluator<TEntity>
    {
        void Evaluate(TEntity entity);
    }
}
