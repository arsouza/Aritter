namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public interface IValidationRule<TEntity>
    {
        string ValidationMessage { get; }

        string ValidationProperty { get; }

        bool Validate(TEntity entity);
    }
}
