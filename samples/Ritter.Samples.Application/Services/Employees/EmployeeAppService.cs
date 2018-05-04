using Ritter.Application.Services;
using Ritter.Domain.Validations;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.TypeAdapter;
using Ritter.Samples.Application.DTO.Base;
using Ritter.Samples.Application.DTO.Employees.Response;
using Ritter.Samples.Domain.Aggregates.Employees;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.Services.Employees
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeAppService(
            ITypeAdapter typeAdapter,
            IEmployeeRepository employeeRepository)
            : base(typeAdapter, null)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task AddValidEmployee()
        {
            try
            {
                var employee = new Employee("", "", "019.570.190-93");
                var validator = new EmployeeValidator();

                validator
                    .Validate(employee)
                    .EnsureValid();

                await employeeRepository.AddAsync(employee);
            }
            catch (Exception)
            {
            }
        }

        public async Task<ICollection<GetEmployeeDto>> ListEmployees(PageFilter pageFilter)
        {
            var employees = await employeeRepository.FindAsync(pageFilter.GetPagination());
            return typeAdapter.Adapt<List<GetEmployeeDto>>(employees);
        }

        public async Task UpdateEmployee(int id)
        {
            try
            {
                employeeRepository.UnitOfWork.BeginTransaction();

                var employee = await employeeRepository.GetAsync(id);
                var validator = new EmployeeValidator();

                var result = validator.Validate(employee);
                result.EnsureValid();

                await employeeRepository.UpdateAsync(employee);

                employeeRepository.UnitOfWork.Commit();
            }
            catch (Exception)
            {
                employeeRepository.UnitOfWork.Rollback();
            }
        }
    }
}
