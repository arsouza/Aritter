using Aritter.Infra.Crosscutting.Collections;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Extensions
{
    public static class PagedListExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            return new PagedList<T>(source, page, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int page, int pageSize, int totalCount)
        {
            return new PagedList<T>(source, page, pageSize, totalCount);
        }
    }
}