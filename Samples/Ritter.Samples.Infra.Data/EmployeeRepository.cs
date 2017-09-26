using Ritter.Infra.Data.Seedwork;
using Ritter.Samples.Domain;

namespace Ritter.Samples.Infra.Data
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
