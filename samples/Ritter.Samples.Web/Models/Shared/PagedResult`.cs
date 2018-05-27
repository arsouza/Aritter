using Ritter.Infra.Crosscutting;
using System.Collections.Generic;

namespace Ritter.Samples.Web.Models.Shared
{
    public sealed class PagedResult<T>
    {
        internal PagedResult(IPagedCollection<T> source)
        {
            TotalCount = source.TotalCount;
            PageCount = source.PageCount;
            Items = source;
        }

        public int TotalCount { get; set; }
        public int PageCount { get; set; }

        public IEnumerable<T> Items { get; set; }
    }
}
