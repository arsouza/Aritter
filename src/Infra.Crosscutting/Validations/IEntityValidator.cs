namespace Ritter.Infra.Crosscutting.Validations
{
    public interface IEntityValidator
    {
        ValidationResult Validate(object item);
    }
}
