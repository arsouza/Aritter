namespace Ritter.Infra.Crosscutting.Validations
{
    public interface IValidatable<TValidatable> : IValidatable where TValidatable : class
    {
        void AddValidations(ValidationContext<TValidatable> context);
    }
}
