using Ritter.Infra.Crosscutting.Collections;

namespace Ritter.Infra.Http.Controllers.Results
{
    public abstract class PagedCollectionResponse<T> where T : class, IPagedCollection
    {
        internal PagedCollectionResponse(T source)
        {
            TotalCount = source.TotalCount;
            Items = source;
        }

        public T Items { get; set; }
        public int TotalCount { get; set; }
    }
}
