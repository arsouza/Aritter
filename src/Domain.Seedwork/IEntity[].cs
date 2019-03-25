using System;

namespace Ritter.Domain
{
    public interface IEntity<TKey> where TKey : struct
    {
        TKey Id { get; }

        Guid Uid { get; }

        bool IsTransient();
    }
}
