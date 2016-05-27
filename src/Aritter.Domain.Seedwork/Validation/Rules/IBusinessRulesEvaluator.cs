namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public interface IBusinessRulesEvaluator<TEntity>
    {
        void Evauluate(TEntity entity);
    }
}
