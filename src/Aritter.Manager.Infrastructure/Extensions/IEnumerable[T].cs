using System;
using System.Collections;
using System.Collections.Generic;

namespace Aritter.Manager.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static IEnumerable<T> ConvertTo<T>(this IEnumerable iterable)
		{
			var toConvert = typeof(T);

			foreach (var item in iterable)
			{
				yield return (T)Convert.ChangeType(item, toConvert);
			}
		}

		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> iterable, Action<T> action)
		{
			if (action == null)
				throw new ArgumentNullException("action");

			foreach (var item in iterable)
			{
				action(item);
				yield return item;
			}
		}

		#endregion Methods
	}
}