using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting
{
    public interface IPagedCollection<out T> : IPagedCollection, IEnumerable<T>
    {
    }
}
