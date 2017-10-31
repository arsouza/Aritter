using System.Linq.Expressions;

namespace System.Linq
{
    public static partial class ExtensionManager
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending)
        {
            return OrderingHelper(source, propertyName, !ascending, false);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, false);
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, false);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, false, true);
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return OrderingHelper(source, propertyName, true, true);
        }

        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty); // I don't care about some naming
            MemberExpression property = null;
            LambdaExpression sort = null;

            foreach (var prop in propertyName.Split('.'))
            {
                property = Expression.PropertyOrField((Expression)property ?? param, prop);
                sort = Expression.Lambda(property, param);
            }

            MethodCallExpression call = Expression.Call(typeof(Queryable),
                                                        (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                                                        new[] { typeof(T), property?.Type },
                                                        source.Expression,
                                                        Expression.Quote(sort));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
    }
}
