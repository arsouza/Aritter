namespace Ritter.Domain.Validation
{
    public interface IValidator
    {
        ValidationResult Validate(object item);
    }
}
