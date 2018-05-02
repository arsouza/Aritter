namespace Ritter.Domain.Validation
{
    public interface IValidable
    {
        void SetupValidation(ValidationContract contract);
    }
}
