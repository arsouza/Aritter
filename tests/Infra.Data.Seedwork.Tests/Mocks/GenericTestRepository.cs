using Ritter.Infra.Data.Seedwork;

namespace Infra.Data.Seedwork.Tests.Mocks
{
    internal class GenericTestRepository : Repository<Test>
    {
        public GenericTestRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
