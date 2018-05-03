namespace Ritter.Domain.Validations
{
    public interface IEntityValidator<TEntity> : IEntityValidator
        where TEntity : class
    {
        ValidationResult Validate(TEntity item);
    }
}
