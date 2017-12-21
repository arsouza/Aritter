using Ritter.Domain.Seedwork.Validation;
using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidationContract<TValidable> where TValidable : class, IValidable
    {
        IReadOnlyCollection<IValidationRule<TValidable>> Rules { get; }
    }
}