using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork;

namespace Infra.Data.Seedwork.Tests.Repositories.Mock
{
    public class GenericTestRepository : Repository<Test>
    {
        public GenericTestRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
