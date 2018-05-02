using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Pagination;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending)
            => OrderingHelper(source, propertyName, !ascending, false);

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
            => OrderingHelper(source, propertyName, false, false);

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
            => OrderingHelper(source, propertyName, true, false);

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
            => OrderingHelper(source, propertyName, false, true);

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
            => OrderingHelper(source, propertyName, true, true);

        public static IQueryable<T> Paginate<T>(this IQueryable<T> dataList, IPagination page)
        {
            Ensure.Argument.NotNull(page, nameof(page));

            var queryableList = dataList;

            if (!page.OrderByName.IsNullOrEmpty())
                queryableList = queryableList.OrderBy(page.OrderByName, page.Ascending);

            queryableList = queryableList.Skip(page.PageIndex * page.PageSize);
            queryableList = queryableList.Take(page.PageSize);

            return queryableList;
        }

        public static async Task<IQueryable<T>> PaginateAsync<T>(this IQueryable<T> dataList, IPagination page)
           => await Task.FromResult(dataList.Paginate(page));

        public static IPagedList<T> PaginateList<T>(this IQueryable<T> dataList, IPagination page)
        {
            Ensure.Argument.NotNull(page, nameof(page));
            return new PagedList<T>(dataList.Paginate<T>(page).ToList(), page.PageSize, dataList.Count());
        }

        public static async Task<IPagedList<T>> PaginateListAsync<T>(this IQueryable<T> dataList, IPagination page)
            => await Task.FromResult(dataList.PaginateList(page));

        private static IOrderedQueryable<T> OrderingHelper<T>(IQueryable<T> source, string propertyName, bool descending, bool anotherLevel)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), string.Empty);
            MemberExpression property = null;
            LambdaExpression sort = null;

            foreach (var prop in propertyName.Split('.'))
            {
                property = Expression.PropertyOrField((Expression)property ?? param, prop);
                sort = Expression.Lambda(property, param);
            }

            MethodCallExpression call = Expression.Call(typeof(Queryable),
                                                        (!anotherLevel ? "OrderBy" : "ThenBy") + (descending ? "Descending" : string.Empty),
                                                        new[] { typeof(T), property.Type },
                                                        source.Expression,
                                                        Expression.Quote(sort));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
    }
}
