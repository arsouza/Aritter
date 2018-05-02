using Ritter.Infra.Crosscutting;
using System;
using System.Collections.Concurrent;

namespace Ritter.Domain.Validations
{
    public class ValidationContractCache
    {
        private readonly ConcurrentDictionary<CacheKey, ValidationContract> cache
            = new ConcurrentDictionary<CacheKey, ValidationContract>();

        private readonly struct CacheKey
        {
            public CacheKey(string entityType, Func<string, ValidationContract> factory)
            {
                EntityType = entityType;
                Factory = factory;
            }

            public string EntityType { get; }

            public Func<string, ValidationContract> Factory { get; }

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

        public virtual ValidationContract GetOrAdd(string entityType, Func<string, ValidationContract> factory)
        {
            Ensure.NotNullOrEmpty(entityType, nameof(entityType));
            return cache.GetOrAdd(new CacheKey(entityType, factory), ck => ck.Factory(ck.EntityType));
        }
    }
}
