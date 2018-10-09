using Ritter.Samples.Domain.Aggregates.People;

namespace Ritter.Samples.Domain.Aggregates.Employees
{
    public static class EmployeeFactory
    {
        public static Employee CreateEmployee(string firstName, string lastName, string cpf)
        {
            Name valueName = new Name(firstName, lastName);
            Cpf valueCpf = new Cpf(cpf);

            return new Employee(valueName, valueCpf);
        }
    }
}
