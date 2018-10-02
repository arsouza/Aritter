using System;

namespace Ritter.Infra.Crosscutting.Validations
{
    public interface IValidationContextCache
    {
        ValidationContext GetOrAdd(Type type, Func<Type, ValidationContext> factory);
    }
}
