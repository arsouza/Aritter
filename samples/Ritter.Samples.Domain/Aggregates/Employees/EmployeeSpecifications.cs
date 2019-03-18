using Ritter.Infra.Crosscutting.Specifications;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public static class EmployeeSpecifications
    {
        public static Specification<Employee> EmployeeHasCpf(string cpf)
        {
            return new DirectSpecification<Employee>(p => p.Cpf.Number == cpf);
        }

        public static Specification<Employee> EmployeeHasId(int employeeId)
        {
            return new DirectSpecification<Employee>(p => p.Id == employeeId);
        }
    }
}
