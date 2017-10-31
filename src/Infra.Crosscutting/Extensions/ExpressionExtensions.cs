using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        public static string GetPropertyName<TSource, TProp>(this Expression<Func<TSource, TProp>> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));

            MemberExpression memberExpression = predicate.Body as MemberExpression;

            if (memberExpression is null)
                memberExpression = (predicate.Body as UnaryExpression)?.Operand as MemberExpression;

            if (memberExpression is null)
                throw new ArgumentException($"Expression '{predicate}' not supported.", nameof(predicate));

            return memberExpression.Member.Name;
        }
    }
}
