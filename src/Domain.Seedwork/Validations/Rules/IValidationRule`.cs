namespace Ritter.Domain.Validations.Rules
{
    public interface IValidationRule<in TValidable> : IValidationRule
        where TValidable : class
    {
        bool IsValid(TValidable entity);
    }
}
