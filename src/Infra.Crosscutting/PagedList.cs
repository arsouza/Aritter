using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ritter.Infra.Crosscutting
{
    [DebuggerStepThrough]
    [DebuggerDisplay("PageCount = {PageCount}; TotalCount = {TotalCount}")]
    public class PagedList<T> : IPagedCollection<T>
    {
        private readonly IEnumerable<T> items;

        public PagedList(IEnumerable<T> items, int totalCount)
        {
            this.items = items ?? Enumerable.Empty<T>();
            PageCount = items.Count();
            TotalCount = totalCount;
        }

        public int TotalCount { get; private set; }

        public int PageCount { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
