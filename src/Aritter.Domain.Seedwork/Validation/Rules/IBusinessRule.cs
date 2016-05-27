#region license



#endregion

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public interface IBusinessRule<TEntity>
    {
        void Evaluate(TEntity entity);
    }
}
