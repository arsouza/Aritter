using Ritter.Infra.Data;
using Ritter.Samples.Domain.Aggregates.Employees;

namespace Ritter.Samples.Infra.Data
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IEFUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
