using System;
using System.Collections.Concurrent;

namespace Ritter.Infra.Crosscutting.Validations
{
    public class ValidationContextCache : IValidationContextCache
    {
        private static IValidationContextCache current = null;

        private readonly ConcurrentDictionary<CacheKey, ValidationContext> cache = new();

        public static IValidationContextCache Current()
        {
            return (current = current ?? new ValidationContextCache());
        }

        public virtual ValidationContext GetOrAdd(Type type, Func<Type, ValidationContext> factory)
        {
            Ensure.NotNull(type, nameof(type));
            return cache.GetOrAdd(new CacheKey(type, factory), ck => ck.Factory(ck.EntityType));
        }

        private readonly struct CacheKey
        {
            public CacheKey(Type entityType, Func<Type, ValidationContext> factory)
            {
                EntityType = entityType;
                Factory = factory;
            }

            public Type EntityType { get; }

            public Func<Type, ValidationContext> Factory { get; }

            private bool Equals(CacheKey other)
            {
                return EntityType.Equals(other.EntityType);
            }

            public override bool Equals(object obj)
            {
                if (obj is null)
                {
                    return false;
                }

                return (obj is CacheKey cacheKey) && Equals(cacheKey);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return EntityType.GetHashCode() * 397;
                }
            }
        }
    }
}
