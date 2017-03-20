using System;

namespace Aritter.Domain.Seedwork
{
    public interface IEntity
    {
        #region Properties

        int Id { get; }

        Guid UID { get; }

        #endregion

        #region Public Methods

        bool IsTransient();

        void GenerateUID();

        void ChangeUID(Guid identity);

        #endregion
    }
}
