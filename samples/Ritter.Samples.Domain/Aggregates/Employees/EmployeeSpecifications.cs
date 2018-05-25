using Ritter.Domain.Specifications;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public static class EmployeeSpecifications
    {
        public static Specification<Employee> EmployeeHasCpf(string cpf)
            => new DirectSpecification<Employee>(p => p.Cpf == cpf);

        public static Specification<Employee> EmployeeHasId(int employeeId)
            => new DirectSpecification<Employee>(p => p.Id == employeeId);
    }
}
