using System;

namespace Aritter.Domain.Seedwork
{
    public interface IRepository : IDisposable
    {
        #region Properties

        IUnitOfWork UnitOfWork { get; }

        #endregion
    }
}