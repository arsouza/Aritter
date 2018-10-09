using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting.Validations
{
    public interface IValidatable
    {
        IReadOnlyCollection<ValidationError> Validations { get; }
        bool Invalid { get; }
        bool Valid { get; }
    }
}
