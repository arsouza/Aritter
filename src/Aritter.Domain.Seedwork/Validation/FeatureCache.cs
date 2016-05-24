using System;
using System.Collections;
using System.Collections.Concurrent;

namespace Aritter.Domain.Seedwork.Validation
{
    internal static class FeatureCache
    {
        private static readonly ConcurrentDictionary<Type, IDictionary> cache;

        static FeatureCache()
        {
            cache = new ConcurrentDictionary<Type, IDictionary>();
        }

        public static void AddCache(Type type, IDictionary features)
        {
            cache.GetOrAdd(type, features);
        }

        public static bool TryGetCache(Type type, out IDictionary result)
        {
            return cache.TryGetValue(type, out result);
        }
    }
}
