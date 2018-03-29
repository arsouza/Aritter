namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidator
    {
        ValidationResult Validate<TValidable>(TValidable item) where TValidable : class, IValidable<TValidable>;
    }
}
