using Ritter.Application.Services;
using Ritter.Infra.Crosscutting.Exceptions;
using Ritter.Infra.Crosscutting.Validations;
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
        private readonly IEntityValidator entityValidator;

        public EmployeeAppService(
            IEmployeeRepository employeeRepository,
            IEntityValidatorFactory validatorFactory)
            : base(null)
        {
            this.employeeRepository = employeeRepository;
            this.entityValidator = validatorFactory.Create();
        }

        public async Task<EmployeeDto> AddEmployee(AddEmployeeDto employeeDto)
        {
            if (employeeDto == null)
                throw new ValidationException("Os dados do funcionário são inválidos");

            var employee = EmployeeFactory.CreateEmployee(
                employeeDto.FirstName,
                employeeDto.LastName,
                employeeDto.Cpf);

            var result = entityValidator.Validate(employee);

            if (!result.IsValid)
                throw new ValidationException(result.Errors.First().ToString());

            if (await employeeRepository.AnyAsync(EmployeeSpecifications.EmployeeHasCpf(employee.Cpf)))
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

            employee.UpdateCpf(employeeDto.Cpf);

            var result = entityValidator.Validate(employee);

            if (!result.IsValid)
                throw new ValidationException(result.Errors.First().ToString());

            if (await employeeRepository.AnyAsync(
                !EmployeeSpecifications.EmployeeHasId(employee.Id)
                && EmployeeSpecifications.EmployeeHasCpf(employee.Cpf)))
            {
                throw new ValidationException("Já existe outro funcionário com este CPF.");
            }

            await employeeRepository.UpdateAsync(employee);

            return employee.ProjectedAs<EmployeeDto>();
        }
    }
}
