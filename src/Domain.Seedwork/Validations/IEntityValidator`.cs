namespace Ritter.Domain.Validations
{
    public interface IEntityValidator<in TEntity> : IEntityValidator
        where TEntity : class
    {
        ValidationResult Validate(TEntity item);
    }
}
