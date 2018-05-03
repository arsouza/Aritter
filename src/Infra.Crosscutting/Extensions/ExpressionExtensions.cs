using Ritter.Infra.Crosscutting;

namespace System.Linq.Expressions
{
    public static partial class ExtensionManager
    {
        public static string GetPropertyName<TSource, TProp>(this Expression<Func<TSource, TProp>> predicate)
        {
            Ensure.Argument.NotNull(predicate, nameof(predicate));

            if (predicate.Body is MemberExpression memberExpression)
                return memberExpression.Member.Name;

            if (predicate.Body is UnaryExpression unaryExpression)
                return (unaryExpression.Operand as MemberExpression).Member.Name;

            throw new ArgumentException($"Expression not supported.", nameof(predicate));
        }
    }
}
