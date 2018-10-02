using Ritter.Samples.Domain.Aggregates.Persons;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public static class EmployeeFactory
    {
        public static Employee CreateEmployee(string firstName, string lastName, string cpf)
        {
            PersonName name = new PersonName(firstName, lastName);
            Employee employee = new Employee(name);
            employee.UpdateCpf(cpf);

            return employee;
        }
    }
}
