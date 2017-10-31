namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public interface IValidationRule<in TEntity>
    {
        string Message { get; }

        bool Validate(TEntity entity);
    }
}
