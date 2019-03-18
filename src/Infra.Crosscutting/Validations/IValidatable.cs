namespace Ritter.Infra.Crosscutting.Validations
{
    public interface IValidatable
    {
        void AddValidations(ValidationContext context);
    }
}
