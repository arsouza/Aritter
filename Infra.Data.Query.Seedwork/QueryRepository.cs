using Ritter.Infra.Crosscutting;

namespace Ritter.Infra.Data.Query
{
    public abstract class QueryRepository : IQueryRepository
    {
        protected QueryRepository(IQueryUnitOfWork unitOfWork)
        {
            Ensure.Argument.NotNull(unitOfWork, nameof(unitOfWork));
            UnitOfWork = unitOfWork;
        }

        public IQueryUnitOfWork UnitOfWork { get; private set; }
    }
}
