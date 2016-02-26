using System;

namespace Aritter.Domain.Seedwork.Aggregates
{
    public interface IEntity
    {
        #region Properties

        int Id { get; set; }

        bool Enabled { get; set; }

        Guid Guid { get; set; }

        #endregion Properties

        #region Methods

        void Enable();
        void Disable();

        #endregion
    }
}