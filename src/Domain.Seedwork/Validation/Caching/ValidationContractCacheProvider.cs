using Ritter.Domain.Seedwork.Validation;
using Ritter.Infra.Crosscutting.Caching;
using System;

namespace Domain.Seedwork.Validation.Caching
{
    public class ValidationContractCacheProvider : CacheProvider, IValidationContractCacheProvider
    {
        public void AddItem(ValidationContract value)
        {
            base.AddItem(value.GetType().Name, value);
        }

        public ValidationContract GetItem<TType>() where TType : ValidationContract
        {
            return GetItem(typeof(TType));
        }

        public ValidationContract GetItem(Type type)
        {
            return base.GetItem(type.Name) as ValidationContract;
        }
    }
}
