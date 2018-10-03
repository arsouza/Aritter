using Ritter.Infra.Crosscutting;
using System.Collections.Generic;

namespace Ritter.Infra.Http.Responses
{
    public class PagedResponse<T> : PagedResponse
    {
        internal PagedResponse(IPagedCollection<T> source)
            : base(source)
        {
            Items = source;
        }

        public new IEnumerable<T> Items { get; set; }
    }
}
