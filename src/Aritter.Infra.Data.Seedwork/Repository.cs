using Aritter.Domain.Seedwork;
using System;

namespace Aritter.Infra.Data.Seedwork
{
    public abstract class Repository : IRepository
    {
        #region Constructors

        protected Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion Constructors

        #region Properties

        public IUnitOfWork UnitOfWork { get; private set; }

        #endregion Properties

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~Repository()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (UnitOfWork != null)
                {
                    UnitOfWork.Dispose();
                    UnitOfWork = null;
                }
            }
        }

        #endregion
    }
}