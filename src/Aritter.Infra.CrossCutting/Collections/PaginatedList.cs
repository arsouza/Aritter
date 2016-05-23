using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Crosscutting.Collections
{
    public class PaginatedList<T> : List<T>, IPaginatedList<T>
    {
        public PaginatedList(IEnumerable<T> source, int page, int pageSize)
            : this(null, page, pageSize, source.Count())
        {
            AddRange(source.Skip(Page * PageSize).Take(PageSize).ToList());
        }

        public PaginatedList(IEnumerable<T> source, int page, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            Page = page < 1 ? 0 : page - 1;
            PageSize = pageSize;

            AddRange(source ?? new T[] { });
        }

        public int TotalCount { get; set; }
        public int Page { get; }
        public int PageSize { get; set; }
        public int PageCount => GetPageCount(PageSize, TotalCount);

        private static int GetPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
            {
                return 0;
            }

            var remainder = totalCount % pageSize;
            return totalCount / pageSize + (remainder == 0 ? 0 : 1);
        }
    }
}