namespace Ritter.Domain.Validations
{
    public interface IValidationRule
    {
        string Property { get; }
        string Message { get; }

        bool Validate(object entity);
    }
}
