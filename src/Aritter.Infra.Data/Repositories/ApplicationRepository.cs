using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Infra.Data.Seedwork;

namespace Aritter.Infra.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
