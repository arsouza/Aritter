using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ritter.Infra.Crosscutting
{
    [DebuggerStepThrough]
    public class PagedList<T> : IPagedCollection<T>
    {
        private readonly IEnumerable<T> items;

        public PagedList(IEnumerable<T> items, int totalCount)
        {
            this.items = items ?? Enumerable.Empty<T>();
            TotalCount = totalCount;
        }

        public int TotalCount { get; private set; }

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();
    }
}
