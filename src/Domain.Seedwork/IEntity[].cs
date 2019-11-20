using System;

namespace Ritter.Domain
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }

        Guid Uid { get; }

        bool IsTransient();
    }
}
