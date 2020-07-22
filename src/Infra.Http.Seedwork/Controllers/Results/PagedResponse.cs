using Ritter.Infra.Crosscutting.Collections;

namespace Ritter.Infra.Http.Controllers.Results
{
    public class PagedResponse : PagedCollectionResponse<IPagedCollection>
    {
        public PagedResponse(IPagedCollection source)
            : base(source)
        {
        }
    }
}
