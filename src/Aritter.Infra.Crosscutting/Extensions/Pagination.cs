using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static partial class ExtensionsMethods
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> dataList, IPagination page)
        {
            return Paginate<T>(dataList.AsQueryable(), page);
        }

        public static async Task<IEnumerable<T>> PaginateAsync<T>(this IEnumerable<T> dataList, IPagination page)
        {
            return await Task.FromResult(dataList.Paginate(page));
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> dataList, IPagination page)
        {
            ValidatePagination(page);

            var queryableList = dataList;

            if (!string.IsNullOrEmpty(page.OrderByName))
                queryableList = queryableList.OrderBy(page.OrderByName, page.Ascending);

            queryableList = queryableList.Skip(page.PageIndex * page.PageSize);
            queryableList = queryableList.Take(page.PageSize);

            return queryableList;
        }

        public static async Task<IQueryable<T>> PaginateAsync<T>(this IQueryable<T> dataList, IPagination page)
        {
            return await Task.FromResult(dataList.Paginate(page));
        }

        public static IPaginatedList<T> PaginateList<T>(this IEnumerable<T> dataList, IPagination page)
        {
            return PaginateList<T>(dataList.AsQueryable(), page);
        }

        public static async Task<IPaginatedList<T>> PaginateListAsync<T>(this IEnumerable<T> dataList, IPagination page)
        {
            return await Task.FromResult(dataList.PaginateList(page));
        }

        public static IPaginatedList<T> PaginateList<T>(this IQueryable<T> dataList, IPagination page)
        {
            return new PaginatedList<T>(dataList.Paginate<T>(page).ToList(), page, dataList.Count());
        }

        public static async Task<IPaginatedList<T>> PaginateListAsync<T>(this IQueryable<T> dataList, IPagination page)
        {
            return await Task.FromResult(dataList.PaginateList(page));
        }

        private static void ValidatePagination(IPagination page)
        {
            Check.Against<ArgumentNullException>(page == null, nameof(page), $"The argument cannot be null.");
            Check.Against<ArgumentException>(page.PageSize < 0, $"The argument must be greater then or equal to 0 (zero).", nameof(page.PageSize));
            Check.Against<ArgumentException>(page.PageIndex < 0, $"The argument must be greater then or equal to 0 (zero).", nameof(page.PageIndex));
        }
    }
}
