namespace Ritter.Domain.Validation
{
    public interface IValidationRule
    {
        string Property { get; }
        string Message { get; }

        bool Validate(object entity);
    }
}
