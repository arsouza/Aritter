using Ritter.Domain.Validation.Fluent;

namespace Ritter.Domain.Validation
{
    public interface IValidationRule<in TValidable> : IValidationRule where TValidable : class, IValidable<TValidable>
    {
        bool Validate(TValidable entity);
    }
}
