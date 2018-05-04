using System;

namespace Ritter.Domain.Validations
{
    public interface IValidationContractCache
    {
        ValidationContract GetOrAdd(Type contractType, Type entityType, Func<Type, Type, ValidationContract> factory);
    }
}
