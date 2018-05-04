using Ritter.Domain;
using Ritter.Infra.Crosscutting;

namespace Ritter.Infra.Data
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
