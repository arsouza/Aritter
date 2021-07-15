using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ritter.Infra.Crosscutting.Collections
{
    [DebuggerStepThrough]
    [DebuggerDisplay("PageCount = {PageCount}; TotalCount = {TotalCount}")]
    public class PagedList<T> : IPagedCollection<T>
    {
        private readonly IEnumerable<T> items;

        public PagedList(IEnumerable<T> items, int totalCount)
        {
            this.items = items ?? new List<T>();
            PageCount = items?.Count() ?? 0;
            TotalCount = totalCount;
        }

        public int TotalCount { get; private set; } = 0;

        public int PageCount { get; private set; } = 0;

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
    }
}
