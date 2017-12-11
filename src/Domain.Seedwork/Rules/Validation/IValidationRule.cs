namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public interface IValidationRule<in TEntity>
    {
        string Property { get; }
        string Message { get; }

        bool Validate(TEntity entity);
    }
}
