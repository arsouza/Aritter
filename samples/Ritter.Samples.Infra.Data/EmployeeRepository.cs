using Ritter.Infra.Data;
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
