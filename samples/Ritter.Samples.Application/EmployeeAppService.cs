using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Infra.Crosscutting.Extensions;
using Ritter.Samples.Domain;
using System;
using System.Threading.Tasks;

namespace Ritter.Samples.Application
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IEntityValidator entityValidator;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeAppService(IEmployeeRepository employeeRepository, IEntityValidator entityValidator) : base(null)
        {
            this.employeeRepository = employeeRepository;
            this.entityValidator = entityValidator;
        }

        public async Task<Employee> AddValidEmployee()
        {
            try
            {
                employeeRepository.UnitOfWork.BeginTransaction();

                Employee employee = new Employee("Test", "Test", "019.570.190-93");
                var validation = entityValidator.Validate(employee);

                if (!validation.IsValid)
                    throw new InvalidOperationException(validation.Errors.Join(", "));

                await employeeRepository.AddAsync(employee);

                employeeRepository.UnitOfWork.Commit();

                return employee;
            }
            catch (Exception)
            {
                employeeRepository.UnitOfWork.Rollback();
                return null;
            }
        }

        public async Task UpdateEmployee(int id)
        {
            var employee = await employeeRepository.GetAsync(id);

            employee.ChangeName("New first name", "New last name");
            var validation = entityValidator.Validate(employee);

            if (!validation.IsValid)
                throw new InvalidOperationException(validation.Errors.Join(", "));

            await employeeRepository.UpdateAsync(employee);
        }
    }
}