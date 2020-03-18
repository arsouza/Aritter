using System.Collections;

namespace Ritter.Infra.Crosscutting
{
    public interface IPagedCollection : IEnumerable
    {
        int PageCount { get; }
        int TotalCount { get; }
    }
}
