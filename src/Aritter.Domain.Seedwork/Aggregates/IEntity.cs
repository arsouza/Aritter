using System;

namespace Aritter.Domain.Seedwork.Aggregates
{
    public interface IEntity
    {
        #region Properties

        int Id { get; set; }

        Guid Guid { get; set; }

        #endregion Properties
    }
}