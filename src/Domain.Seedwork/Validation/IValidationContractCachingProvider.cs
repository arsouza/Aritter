using System;
using Ritter.Domain.Seedwork.Validation;

namespace Domain.Seedwork.Validation
{
    public interface IValidationContractCachingProvider
    {
        void AddItem(ValidationContract value);
        ValidationContract GetItem<TType>() where TType : ValidationContract;
        ValidationContract GetItem(Type type);
    }
}
