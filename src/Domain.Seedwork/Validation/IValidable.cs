using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidable<in TValidable> where TValidable : class
    {
        ValidationResult Validate();
    }
}