using Ritter.Infra.Data;

namespace Ritter.Infra.Data.Tests.Mocks
{
    internal class GenericTestRepository : EFRepository<Test>
    {
        public GenericTestRepository(IEFUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
