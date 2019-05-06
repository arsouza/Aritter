using System.Collections;
using Ritter.Infra.Crosscutting;

namespace Ritter.Infra.Http.Controllers.Results
{
    public class PagedResult
    {
        internal PagedResult(IPagedCollection source)
        {
            TotalCount = source.TotalCount;
            Items = source;
        }

        public IEnumerable Items { get; set; }
        public int TotalCount { get; set; }
    }
}
