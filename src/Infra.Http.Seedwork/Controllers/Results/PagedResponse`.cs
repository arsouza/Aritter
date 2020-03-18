using Ritter.Infra.Crosscutting;

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
