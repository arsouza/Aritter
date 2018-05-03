namespace Ritter.Domain.Validations
{
    public interface IEntityValidator
    {
        ValidationResult Validate(object item);
    }
}
