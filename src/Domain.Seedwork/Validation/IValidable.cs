using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidable
    {
        ValidationResult Validate();
    }
}