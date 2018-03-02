using System;
using Infra.Crosscutting.Caching;
using Microsoft.Extensions.Caching.Memory;
using Ritter.Domain.Seedwork.Validation;

namespace Domain.Seedwork.Validation
{
    public class ValidationContractCachingProvider : CachingProvider, IValidationContractCachingProvider
    {
        public ValidationContractCachingProvider(IMemoryCache memoryCache) : base(memoryCache)
        {
        }

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
