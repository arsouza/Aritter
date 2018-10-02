using System;

namespace Ritter.Domain.Validations
{
    public interface IValidationContextCache
    {
        ValidationContext GetOrAdd(Type type, Func<Type, ValidationContext> factory);
    }
}
