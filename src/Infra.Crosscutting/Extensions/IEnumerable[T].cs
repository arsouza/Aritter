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

        #endregion Methods
    }
}