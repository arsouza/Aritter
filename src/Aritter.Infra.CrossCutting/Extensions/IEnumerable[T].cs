using System;
using System.Collections;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static IEnumerable<T> ConvertTo<T>(this IEnumerable target)
		{
			var toType = typeof(T);

			foreach (var item in target)
			{
				yield return (T)Convert.ChangeType(item, toType);
			}
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> target, Action<T> action)
		{
			if (target == null)
			{
				yield break;
			}

			foreach (var item in target)
			{
				action(item);
				yield return item;
			}
		}

		#endregion Methods
	}
}