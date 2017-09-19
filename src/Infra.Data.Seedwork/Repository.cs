using Ritter.Domain.Seedwork;
using Ritter.Infra.Crosscutting.Exceptions;

namespace Ritter.Infra.Data.Seedwork
{
    public abstract class Repository : IRepository
    {
        private bool disposed = false;

        protected Repository(IUnitOfWork unitOfWork)
        {
            Check.IsNotNull(unitOfWork, nameof(unitOfWork));
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    UnitOfWork?.Dispose();
                    UnitOfWork = null;
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
