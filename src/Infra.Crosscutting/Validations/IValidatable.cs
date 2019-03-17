namespace Ritter.Infra.Crosscutting.Validations
{
    public interface IValidatable
    {
        void ValidationSetup(ValidationContext context);
    }
}
