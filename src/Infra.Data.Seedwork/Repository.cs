using Ritter.Domain.Seedwork;
using System;

namespace Ritter.Infra.Data.Seedwork
{
    public abstract class Repository : IRepository
    {
        protected Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IUnitOfWork UnitOfWork { get; private set; }
    }
}
