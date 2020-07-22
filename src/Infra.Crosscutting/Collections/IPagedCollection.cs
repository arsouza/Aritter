using System.Collections;

namespace Ritter.Infra.Crosscutting.Collections
{
    public interface IPagedCollection : IEnumerable
    {
        int PageCount { get; }
        int TotalCount { get; }
    }
}
