using System.Collections;
using Ritter.Infra.Crosscutting;

namespace Ritter.Infra.Http.Responses
{
    public class PagedResponse
    {
        internal PagedResponse(IPagedCollection source)
        {
            TotalCount = source.TotalCount;
            Items = source;
        }

        public IEnumerable Items { get; set; }
        public int TotalCount { get; set; }
    }
}
