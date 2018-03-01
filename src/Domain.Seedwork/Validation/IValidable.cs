namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidable
    {
        void SetupValidation(ValidationContract contract);
    }
}
