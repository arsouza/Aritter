using System.Linq;
using System.Threading.Tasks;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Collections;

namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static IEnumerable ForEach(this IEnumerable source, Action<object> action)
        {
            Ensure.ArgumentNotNull(source, nameof(source));
            Ensure.ArgumentNotNull(action, nameof(action));

            foreach (object item in source)
            {
                action(item);
            }

            return source;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Ensure.ArgumentNotNull(source, nameof(source));
            Ensure.ArgumentNotNull(action, nameof(action));

            foreach (T element in source)
            {
                action(element);
            }

            return source;
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
            Ensure.ArgumentNotNull(page, nameof(page));
            return new PagedList<T>(dataList.Paginate<T>(page).ToList(), dataList.Count());
        }

        public static async Task<IPagedCollection<T>> PaginateListAsync<T>(this IQueryable<T> dataList, IPagination page)
        {
            return await Task.FromResult(dataList.PaginateList(page));
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> dataList, IPagination page)
        {
            Ensure.ArgumentNotNull(page, nameof(page));

            IQueryable<T> queryableList = dataList;

            if (!page.OrderByName.IsNullOrEmpty())
            {
                queryableList = queryableList.OrderBy(page.OrderByName, page.Ascending);
            }

            queryableList = queryableList.Skip(page.PageIndex * page.PageSize);
            queryableList = queryableList.Take(page.PageSize);

            return queryableList;
        }

        public static IPagedCollection<TResult> Select<TSource, TResult>(this IPagedCollection<TSource> source, Func<TSource, TResult> selector)
        {
            IEnumerable<TResult> items = ((IEnumerable<TSource>)source).Select(selector);
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
