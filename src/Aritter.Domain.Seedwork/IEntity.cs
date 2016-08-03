using System;

namespace Aritter.Domain.Seedwork
{
    public interface IEntity
    {
        #region Properties

        int Id { get; }

        bool Enabled { get; }

        Guid UID { get; }

        #endregion

        #region Public Methods

        bool IsTransient();

        void GenerateUID();

        void ChangeUID(Guid identity);

        void Enable();

        void Disable();

        #endregion
    }
}