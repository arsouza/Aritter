namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public interface IValidationRule
    {
        string Property { get; }
        string Message { get; }

        bool IsValid(object entity);
    }
}
