using System.Collections;

namespace Ritter.Infra.Crosscutting
{
    public interface IPagedCollection : IEnumerable
    {
        int TotalCount { get; }
        int PageCount { get; }
        int PageSize { get; }
    }
}
