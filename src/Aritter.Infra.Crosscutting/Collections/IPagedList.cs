using System.Collections;
using System.Collections.Generic;

namespace Aritter.Infra.Crosscutting.Collections
{
    public interface IPagedList<T> : IList<T>, IList, IReadOnlyList<T>
    {
        int TotalCount { get; }
        int PageCount { get; }
        int Page { get; }
        int PageSize { get; }
    }
}