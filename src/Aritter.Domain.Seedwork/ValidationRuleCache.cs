using System;
using System.Collections;
using System.Collections.Concurrent;

namespace Aritter.Domain.Seedwork
{
	internal static class ValidationRuleCache
	{
		private static readonly ConcurrentDictionary<Type, IDictionary> cache;

		static ValidationRuleCache()
		{
			cache = new ConcurrentDictionary<Type, IDictionary>();
		}

		public static void AddCache(Type type, IDictionary rules)
		{
			cache.GetOrAdd(type, rules);
		}

		public static bool TryGetCache(Type type, out IDictionary result)
		{
			return cache.TryGetValue(type, out result);
		}
	}
}
