using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aritter.Infra.Cosscutting.Extensions
{
    public static partial class ExtensionsMethods
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> dataList, IPagination page)
        {
            return Paginate<T>(dataList.AsQueryable(), page);
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> dataList, IPagination page)
        {
            ValidatePagination(page);

            var quaryableList = dataList;

            if (!string.IsNullOrEmpty(page.OrderByName))
                quaryableList = quaryableList.OrderBy(page.OrderByName, page.Ascending);

            if (page.PageSize > 0)
            {
                quaryableList = quaryableList.Skip(page.PageIndex * page.PageSize);
                quaryableList = quaryableList.Take(page.PageSize);
            }

            return quaryableList;
        }

        public static IPaginatedList<T> PaginateList<T>(this IEnumerable<T> dataList, IPagination page)
        {
            return PaginateList<T>(dataList.AsQueryable(), page);
        }

        public static IPaginatedList<T> PaginateList<T>(this IQueryable<T> dataList, IPagination page)
        {
            return new PaginatedList<T>(dataList.Paginate<T>(page).ToList(), page, dataList.Count());
        }

        private static void ValidatePagination(IPagination page)
        {
            Check.Against<ArgumentNullException>(page == null, nameof(page), $"The argument cannot be null.");
            Check.Against<ArgumentException>(page.PageSize <= 0, $"The argument must be greater then 0 (zero).", nameof(page.PageSize));
            Check.Against<ArgumentException>(page.PageIndex < 0, $"The argument must be greater then or equal to 0 (zero).", nameof(page.PageIndex));
        }
    }
}