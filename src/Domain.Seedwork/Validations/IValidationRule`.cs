namespace Ritter.Domain.Validations
{
    public interface IValidationRule<in TValidable> : IValidationRule where TValidable : class
    {
        bool Validate(TValidable entity);
    }
}
