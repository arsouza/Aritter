namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidator
    {
        ValidationResult Validate(object item);
    }
}
