using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public interface IEntityValidator
    {
        ValidationResult Validate<TValidable>(TValidable item) where TValidable : class, IValidable<TValidable>;
    }
}
