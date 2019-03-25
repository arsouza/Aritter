using Ritter.Infra.Crosscutting;
using System.Linq;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static void ForEach(this IEnumerable source, Action<object> action)
        {
            Ensure.Argument.NotNull(source, nameof(source));
            Ensure.Argument.NotNull(action, nameof(action));

            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Ensure.Argument.NotNull(source, nameof(source));
            Ensure.Argument.NotNull(action, nameof(action));

            foreach (var item in source)
            {
                action(item);
            }
        }

        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> values, IPagination page)
        {
            return Paginate<T>(values.AsQueryable(), page);
        }

        public static async Task<IEnumerable<T>> PaginateAsync<T>(this IEnumerable<T> values, IPagination page)
        {
            return await PaginateAsync<T>(values.AsQueryable(), page);
        }

        public static IPagedCollection<T> PaginateList<T>(this IEnumerable<T> values, IPagination page)
        {
            return PaginateList<T>(values.AsQueryable(), page);
        }

        public static async Task<IPagedCollection<T>> PaginateListAsync<T>(this IEnumerable<T> values, IPagination page)
        {
            return await PaginateListAsync<T>(values.AsQueryable(), page);
        }

        public static async Task<IQueryable<T>> PaginateAsync<T>(this IQueryable<T> dataList, IPagination page)
        {
            return await Task.FromResult(dataList.Paginate(page));
        }

        public static IPagedCollection<T> PaginateList<T>(this IQueryable<T> dataList, IPagination page)
        {
            Ensure.Argument.NotNull(page, nameof(page));
            return new PagedList<T>(dataList.Paginate<T>(page).ToList(), dataList.Count());
        }

        public static async Task<IPagedCollection<T>> PaginateListAsync<T>(this IQueryable<T> dataList, IPagination page)
        {
            return await Task.FromResult(dataList.PaginateList(page));
        }

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

        public static IPagedCollection<TResult> Select<TSource, TResult>(this IPagedCollection<TSource> source, Func<TSource, TResult> selector)
        {
            var items = ((IEnumerable<TSource>)source).Select(selector);
            return new PagedList<TResult>(items, source.TotalCount);
        }

        public static string Join(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values);
        }

        public static string Join<T>(this IEnumerable<T> values, string separator)
        {
            return string.Join(separator, values);
        }
    }
}
