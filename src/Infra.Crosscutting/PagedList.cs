using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ritter.Infra.Crosscutting
{
    public class PagedList<T> : IPagedCollection<T>
    {
        private IEnumerable<T> items = Enumerable.Empty<T>();

        public PagedList(IEnumerable<T> items, int pageSize, int pageCount, int totalCount)
        {
            this.items = items;

            PageSize = pageSize;
            PageCount = pageCount;
            TotalCount = totalCount;
        }

        public PagedList(IEnumerable<T> items, int pageSize, int totalCount)
            : this(items, pageSize, GetTotalPage(pageSize, totalCount), totalCount)
        {
        }

        public int TotalCount { get; private set; }

        public int PageCount { get; private set; }

        public int PageSize { get; private set; }

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        private static int GetTotalPage(int pageSize, int totalCount)
        {
            if (pageSize == 0)
                return 0;

            var remainder = totalCount % pageSize;
            return totalCount / pageSize + (remainder == 0 ? 0 : 1);
        }
    }
}
