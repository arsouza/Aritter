using Ritter.Infra.Crosscutting.Collections;

namespace Ritter.Infra.Http.Controllers.Results
{
    public class PagedResponse<T> : PagedCollectionResponse<IPagedCollection<T>>
    {
        public PagedResponse(IPagedCollection<T> source)
            : base(source)
        {
        }
    }
}
