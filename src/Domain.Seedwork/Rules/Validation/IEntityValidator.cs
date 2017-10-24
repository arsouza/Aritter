namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public interface IEntityValidator<TEntity>
        where TEntity : class, IValidatableEntity<TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}
