using System;

namespace Ritter.Domain
{
    public interface IEntity
    {
        int Id { get; }

        Guid Uid { get; }

        bool IsTransient();
    }
}
