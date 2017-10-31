using System;

namespace Ritter.Domain.Seedwork
{
    public interface IEntity
    {
        int Id { get; }

        Guid Uid { get; }

        bool IsTransient();
    }
}
