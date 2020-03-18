using Ritter.Infra.Crosscutting;
using System.Collections.Generic;

namespace Ritter.Infra.Http.Controllers.Results
{
    public class PagedResult<T> : PagedResult
    {
        internal PagedResult(IPagedCollection<T> source)
            : base(source)
        {
            Items = source;
        }

        public new IEnumerable<T> Items { get; set; }
    }
}
