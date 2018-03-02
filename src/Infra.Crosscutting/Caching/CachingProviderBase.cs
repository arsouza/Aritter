using System;
using Microsoft.Extensions.Caching.Memory;

namespace Infra.Crosscutting.Caching
{
    public abstract class CachingProvider
    {
        protected readonly IMemoryCache cache;

        public CachingProvider(IMemoryCache memoryCache)
        {
            cache = memoryCache;
        }

        static readonly object padlock = new object();

        protected virtual void AddItem(string key, object value)
        {
            lock (padlock)
            {
                cache.Set(key, value, DateTimeOffset.MaxValue);
            }
        }

        protected virtual void RemoveItem(string key)
        {
            lock (padlock)
            {
                cache.Remove(key);
            }
        }

        protected virtual object GetItem(string key)
        {
            return GetItem(key, false);
        }

        protected virtual object GetItem(string key, bool remove)
        {
            lock (padlock)
            {
                object res;

                if (cache.TryGetValue(key, out res))
                {
                    if (remove == true)
                        cache.Remove(key);
                }

                return res;
            }
        }
    }
}
