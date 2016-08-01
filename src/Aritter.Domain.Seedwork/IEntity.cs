using System;

namespace Aritter.Domain.Seedwork
{
    public interface IEntity
    {
        #region Properties

        int Id { get; }

        bool IsEnabled { get; }

        Guid UID { get; }

        #endregion

        #region Public Methods

        bool IsTransient();

        void GenerateIdentity();

        void ChangeCurrentIdentity(Guid identity);

        void Enable();

        void Disable();

        #endregion
    }
}