using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionManager
    {
        public static string GetPropertyName<TSource, TProp>(this Expression<Func<TSource, TProp>> expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            MemberExpression memberExpression = null;

            if (expression.Body is MemberExpression)
                memberExpression = (MemberExpression)expression.Body;
            else if (expression.Body is UnaryExpression)
                memberExpression = (MemberExpression)((UnaryExpression)expression.Body).Operand;
            else
                throw new ArgumentException($"Expression '{expression}' not supported.", nameof(expression));

            return memberExpression.Member.Name;
        }
    }
}
