using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting.Caching
{
    public abstract class CacheProvider
    {
        private readonly Dictionary<string, object> cache = new Dictionary<string, object>();

        static readonly object padlock = new object();

        protected virtual void AddItem(string key, object value)
        {
            lock (padlock)
            {
                cache.Add(key, value);
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
                if (cache.TryGetValue(key, out object res))
                {
                    if (remove)
                        cache.Remove(key);
                }

                return res;
            }
        }
    }
}
