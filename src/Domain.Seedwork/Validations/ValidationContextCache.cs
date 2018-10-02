using Ritter.Infra.Crosscutting;
using System;
using System.Collections.Concurrent;

namespace Ritter.Domain.Validations
{
    public class ValidationContextCache : IValidationContextCache
    {
        private static IValidationContextCache current = null;

        private readonly ConcurrentDictionary<Type, ValidationContext> cache;

        private ValidationContextCache()
        {
            cache = new ConcurrentDictionary<Type, ValidationContext>();
        }

        public static IValidationContextCache Current() => (current = current ?? new ValidationContextCache());

        public virtual ValidationContext GetOrAdd(Type type, Func<Type, ValidationContext> factory)
        {
            Ensure.NotNull(type, nameof(type));

            return cache.GetOrAdd(type, factory?.Invoke(type));
        }
    }
}
