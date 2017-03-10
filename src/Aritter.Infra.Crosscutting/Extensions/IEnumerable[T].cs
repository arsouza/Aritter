using System;
using System.Collections;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        #region Methods

        public static IEnumerable<T> ConvertTo<T>(this IEnumerable source)
        {
            var toType = typeof(T);

            foreach (var item in source)
            {
                yield return (T)Convert.ChangeType(item, toType);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {            
            foreach (var item in source)
            {
                action(item);
            }
        }

        #endregion Methods
    }
}