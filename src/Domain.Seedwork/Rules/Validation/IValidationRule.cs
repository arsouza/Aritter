namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public interface IValidationRule<TEntity>
    {
        string Message { get; }

        bool Validate(TEntity entity);
    }
}
