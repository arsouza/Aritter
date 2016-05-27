namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public interface IEntityValidator<TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}
