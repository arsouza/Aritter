using System.Collections.Generic;
using System.Linq;

namespace Ritter.Infra.Crosscutting
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int pageSize, int totalCount)
        {
            PageSize = pageSize;
            TotalCount = totalCount;
            PageCount = GetTotalPage(PageSize, TotalCount);
            AddRange(source);
        }

        public PagedList()
            : this(Enumerable.Empty<T>(), 0, 0)
        {
        }

        public int TotalCount { get; private set; }

        public int PageCount { get; private set; }

        public int PageSize { get; private set; }

        private static int GetTotalPage(int pageSize, int totalCount)
        {
            if (pageSize == 0)
                return 0;

            var remainder = totalCount % pageSize;
            return totalCount / pageSize + (remainder == 0 ? 0 : 1);
        }
    }
}
