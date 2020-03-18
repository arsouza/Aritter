using System.Collections.Generic;
using System.Linq;

namespace Ritter.Infra.Crosscutting.Extensions
{
    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> NullIfEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null || !dictionary.Any())
            {
                return null;
            }

            return dictionary;
        }
    }
}
