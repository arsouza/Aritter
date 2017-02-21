using Aritter.Infra.Crosscutting.Collections;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static class PaginatedListExtensions
    {
        public static PaginatedList<T> ToPaginatedList<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            return new PaginatedList<T>(source, page, pageSize);
        }

        public static PaginatedList<T> ToPaginatedList<T>(this IEnumerable<T> source, int page, int pageSize, int totalCount)
        {
            return new PaginatedList<T>(source, page, pageSize, totalCount);
        }
    }
}