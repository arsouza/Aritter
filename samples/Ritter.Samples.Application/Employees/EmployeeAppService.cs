using Ritter.Application.Services;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Exceptions;
using Ritter.Infra.Crosscutting.Validations;
using Ritter.Samples.Application.DTO.Employees.Request;
using Ritter.Samples.Application.DTO.Employees.Response;
using Ritter.Samples.Domain.Aggregates.Employees;
using System;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.Employees
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeAppService(
            IEmployeeRepository employeeRepository)
            : base(null)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto> AddEmployee(AddEmployeeDto employeeDto)
        {
            var employee = new Employee(
                employeeDto.FirstName,
                employeeDto.LastName,
                employeeDto.Cpf);

            var validator = EntityValidatorFactory.CreateValidator();

            validator
                .Validate(employee)
                .EnsureValid();

            bool existsEmployee = await employeeRepository
                .AnyAsync(EmployeeSpecifications.EmployeeHasCpf(employee.Cpf));

            Ensure.Not<ValidationException>(
                existsEmployee,
                "Já existe um funcionário com este CPF.");

            await employeeRepository
                .AddAsync(employee);

            return employee.ProjectedAs<EmployeeDto>();
        }

        public async Task<EmployeeDto> UpdateEmployee(int employeeId, UpdateEmployeeDto employeeDto)
        {
            var employee = await employeeRepository
                .GetAsync(employeeId);

            Ensure.That<NotFoundObjectException>(
                !employee.IsNull(),
                "Funcionário não encontrado.");

            employee.UpdateCpf(employeeDto.Cpf);

            var validator = EntityValidatorFactory.CreateValidator();

            validator
                .Validate(employee)
                .EnsureValid();

            bool existsEmployee = await employeeRepository
                .AnyAsync(
                    !EmployeeSpecifications.EmployeeHasId(employee.Id)
                    && EmployeeSpecifications.EmployeeHasCpf(employee.Cpf));

            Ensure.Not<ValidationException>(
                existsEmployee,
                "Já existe outro funcionário com este CPF.");

            await employeeRepository
                .UpdateAsync(employee);

            return employee.ProjectedAs<EmployeeDto>();
        }
    }
}
