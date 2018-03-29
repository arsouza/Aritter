using Ritter.Domain.Seedwork;
using Ritter.Infra.Crosscutting;

namespace Ritter.Infra.Data.Seedwork
{
    public abstract class Repository : IRepository
    {
        protected Repository(IUnitOfWork unitOfWork)
        {
            Ensure.Argument.NotNull(unitOfWork, nameof(unitOfWork));
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; private set; }
    }
}
