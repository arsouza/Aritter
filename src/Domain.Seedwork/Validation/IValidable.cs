using Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidable
    {
        IValidationContract<TValidable> ConfigureValidation<TValidable>() where TValidable : class, IValidable;
    }
}