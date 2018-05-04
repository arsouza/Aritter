using System.Collections.Generic;

namespace Ritter.Application.Models
{
    public static class PagedResult
    {
        public static PagedResult<TItem> FromList<TItem>(ICollection<TItem> list, int pageCount, int totalCount)
            => new PagedResult<TItem>(list, pageCount, totalCount);
    }
}
