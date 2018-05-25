using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting
{
    public interface IPagedCollection<out T> : IEnumerable<T>
    {
        int TotalCount { get; }
        int PageCount { get; }
        int PageSize { get; }
    }
}
