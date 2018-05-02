using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Pagination;
using System.Linq;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
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
            => Paginate<T>(values.AsQueryable(), page);

        public static async Task<IEnumerable<T>> PaginateAsync<T>(this IEnumerable<T> values, IPagination page)
            => await PaginateAsync<T>(values.AsQueryable(), page);

        public static IPagedList<T> PaginateList<T>(this IEnumerable<T> values, IPagination page)
            => PaginateList<T>(values.AsQueryable(), page);

        public static async Task<IPagedList<T>> PaginateListAsync<T>(this IEnumerable<T> values, IPagination page)
            => await PaginateListAsync<T>(values.AsQueryable(), page);

        public static string Join(this IEnumerable<string> values, string separator)
            => string.Join(separator, values);

        public static string Join<T>(this IEnumerable<T> values, string separator)
            => string.Join(separator, values);
    }
}
