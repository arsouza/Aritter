using System.Collections.Generic;

namespace Ritter.Infra.Crosscutting.Collections
{
    public interface IPagedCollection<out T> : IPagedCollection, IEnumerable<T>
    {
    }
}
