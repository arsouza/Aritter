using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork;

namespace Ritter.Infra.Data.Seedwork.Tests.Mocks
{
    internal class TestRepository : Repository
    {
        public TestRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
