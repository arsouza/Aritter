using Ritter.Domain;
using Ritter.Infra.Data;

namespace Ritter.Infra.Data.Tests.Mocks
{
    internal class TestRepository : Repository
    {
        public TestRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
