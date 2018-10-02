namespace Ritter.Domain.Validations
{
    public interface IValidatableEntity
    {
        void ValidationSetup(ValidationContext context);
    }
}
