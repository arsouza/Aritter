#region license



#endregion

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public interface IValidationRule<TEntity>
    {
        string ValidationMessage { get; }

        string ValidationProperty { get; }

        bool Validate(TEntity entity);
    }
}
