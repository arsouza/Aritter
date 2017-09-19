using System;

namespace Ritter.Domain.Seedwork
{
    public interface IEntity
    {
        int Id { get; }

        Guid UID { get; }

        bool IsTransient();

        void GenerateUID();

        void ChangeUID(Guid identity);
    }
}
