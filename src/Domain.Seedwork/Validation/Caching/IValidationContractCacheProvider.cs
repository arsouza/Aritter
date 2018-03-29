using Ritter.Domain.Seedwork.Validation;
using System;

namespace Domain.Seedwork.Validation.Caching
{
    public interface IValidationContractCacheProvider
    {
        void AddItem(ValidationContract value);
        ValidationContract GetItem<TType>() where TType : ValidationContract;
        ValidationContract GetItem(Type type);
    }
}
