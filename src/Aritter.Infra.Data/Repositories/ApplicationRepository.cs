using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork;

namespace Aritter.Infra.Data.Repositories
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
