namespace Aritter.Domain.Seedwork.Rules.Business
{
    public interface IBusinessRulesEvaluator<TEntity>
    {
        void Evauluate(TEntity entity);
    }
}
