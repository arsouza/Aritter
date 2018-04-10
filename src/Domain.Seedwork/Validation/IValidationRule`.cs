using Ritter.Domain.Seedwork.Validation.Fluent;

namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidationRule<in TValidable> : IValidationRule where TValidable : class, IValidable<TValidable>
    {
        bool Validate(TValidable entity);
    }
}
