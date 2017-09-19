using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork;

namespace Infra.Data.Seedwork.Tests.Repositories.Mock
{
    public class TestRepository : Repository
    {
        public TestRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
