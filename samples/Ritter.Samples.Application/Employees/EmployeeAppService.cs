using Ritter.Application.Services;
using Ritter.Infra.Crosscutting.Exceptions;
using Ritter.Samples.Application.DTO.Employees.Request;
using Ritter.Samples.Application.DTO.Employees.Response;
using Ritter.Samples.Domain.Aggregates.Employees;
using System.Linq;
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
            if (employeeDto == null)
                throw new ValidationException("Os dados do funcionário são inválidos");

            var employee = EmployeeFactory.CreateEmployee(
                employeeDto.FirstName,
                employeeDto.LastName,
                employeeDto.Cpf);

            if (employee.Invalid)
                throw new ValidationException(employee.Validations.First().ToString());

            if (await employeeRepository.AnyAsync(EmployeeSpecifications.EmployeeHasCpf(employee.Cpf.Value)))
                throw new ValidationException("Já existe um funcionário com este CPF.");

            await employeeRepository.AddAsync(employee);

            return employee.ProjectedAs<EmployeeDto>();
        }

        public async Task<EmployeeDto> UpdateEmployee(int employeeId, UpdateEmployeeDto employeeDto)
        {
            if (employeeDto == null)
                throw new ValidationException("Os dados do funcionário são inválidos");

            var employee = await employeeRepository.GetAsync(employeeId)
                ?? throw new NotFoundObjectException("Funcionário não encontrado.");

            // Update employee

            if (employee.Invalid)
                throw new ValidationException(employee.Validations.First().ToString());

            if (await employeeRepository.AnyAsync(
                !EmployeeSpecifications.EmployeeHasId(employee.Id)
                && EmployeeSpecifications.EmployeeHasCpf(employee.Cpf.Value)))
            {
                throw new ValidationException("Já existe outro funcionário com este CPF.");
            }

            await employeeRepository.UpdateAsync(employee);

            return employee.ProjectedAs<EmployeeDto>();
        }
    }
}
