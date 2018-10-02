namespace Ritter.Infra.Crosscutting.Validations
{
    public interface IValidatableEntity
    {
        void ValidationSetup(ValidationContext context);
    }
}
