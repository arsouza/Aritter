namespace Ritter.Domain.Seedwork.Validation.Fluent
{
    public interface IFluentValidator : IValidator
    {
        ValidationResult Validate<TValidable>(TValidable item) where TValidable : class, IValidable<TValidable>;
    }
}
