using System.Collections.Generic;

namespace Ritter.Application.Models
{
    public sealed class PagedResult<T>
    {
        public PagedResult(ICollection<T> page, int pageCount, int totalCount)
        {
            TotalCount = totalCount;
            PageCount = pageCount;
            Items = page;
        }

        public int TotalCount { get; set; }
        public int PageCount { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
