using Ritter.Infra.Crosscutting;
using System;
using System.Collections.Concurrent;

namespace Ritter.Domain.Validations
{
    public class ValidationContractCache : IValidationContractCache
    {
        private readonly ConcurrentDictionary<CacheKey, ValidationContract> cache
            = new ConcurrentDictionary<CacheKey, ValidationContract>();

        private readonly struct CacheKey
        {
            public CacheKey(Type contractType, Type entityType, Func<Type, Type, ValidationContract> factory)
            {
                ContractType = contractType;
                EntityType = entityType;
                Factory = factory;
            }

            public Type ContractType { get; }

            public Type EntityType { get; }

            public Func<Type, Type, ValidationContract> Factory { get; }

            private bool Equals(CacheKey other)
                => EntityType.Equals(other.EntityType);

            public override bool Equals(object obj)
            {
                if (obj.IsNull())
                    return false;

                return obj.Is<CacheKey>() && Equals((CacheKey)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (EntityType.GetHashCode() * 397);
                }
            }
        }

        public virtual ValidationContract GetOrAdd(Type contractType, Type entityType, Func<Type, Type, ValidationContract> factory)
        {
            Ensure.NotNull(contractType, nameof(entityType));
            Ensure.NotNull(entityType, nameof(entityType));
            return cache.GetOrAdd(new CacheKey(contractType, entityType, factory), ck => ck.Factory(ck.ContractType, ck.EntityType));
        }
    }
}
