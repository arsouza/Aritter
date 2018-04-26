using Ritter.Infra.Crosscutting.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionsMethods
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> dataList, IPagination page)
            => Paginate<T>(dataList.AsQueryable(), page);

        public static async Task<IEnumerable<T>> PaginateAsync<T>(this IEnumerable<T> dataList, IPagination page)
            => await PaginateAsync<T>(dataList.AsQueryable(), page);

        public static IQueryable<T> Paginate<T>(this IQueryable<T> dataList, IPagination page)
        {
            ValidatePagination(page);

            var queryableList = dataList;

            if (!page.OrderByName.IsNullOrEmpty())
                queryableList = queryableList.OrderBy(page.OrderByName, page.Ascending);

            queryableList = queryableList.Skip(page.PageIndex * page.PageSize);
            queryableList = queryableList.Take(page.PageSize);

            return queryableList;
        }

        public static async Task<IQueryable<T>> PaginateAsync<T>(this IQueryable<T> dataList, IPagination page)
            => await Task.FromResult(dataList.Paginate(page));

        public static IPagedList<T> PaginateList<T>(this IEnumerable<T> dataList, IPagination page)
            => PaginateList<T>(dataList.AsQueryable(), page);

        public static async Task<IPagedList<T>> PaginateListAsync<T>(this IEnumerable<T> dataList, IPagination page)
            => await PaginateListAsync<T>(dataList.AsQueryable(), page);

        public static IPagedList<T> PaginateList<T>(this IQueryable<T> dataList, IPagination page)
        {
            Ensure.Argument.NotNull(page, nameof(page));
            return new PagedList<T>(dataList.Paginate<T>(page).ToList(), page.PageSize, dataList.Count());
        }

        public static async Task<IPagedList<T>> PaginateListAsync<T>(this IQueryable<T> dataList, IPagination page) => await Task.FromResult(dataList.PaginateList(page));

        private static void ValidatePagination(IPagination page)
        {
            Ensure.Argument.NotNull(page, nameof(page));
            Ensure.Argument.Is(page.PageSize >= 0, $"The {nameof(IPagination.PageSize)} argument must be greater then or equal to 0 (zero).");
            Ensure.Argument.Is(page.PageIndex >= 0, $"The {nameof(IPagination.PageIndex)} argument must be greater then or equal to 0 (zero).");
        }
    }
}
