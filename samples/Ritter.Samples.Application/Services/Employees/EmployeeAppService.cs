using Ritter.Application.Models;
using Ritter.Application.Services;
using Ritter.Domain.Validations;
using Ritter.Infra.Crosscutting.TypeAdapter;
using Ritter.Samples.Application.DTO.Employees.Request;
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

        public async Task<GetEmployeeDto> AddEmployee(PostEmployeeDto employeeDto)
        {
            var employee = new Employee(employeeDto.FirstName, employeeDto.LastName, employeeDto.Cpf);
            await employeeRepository.AddAsync(employee);

            return typeAdapter.Adapt<GetEmployeeDto>(employee);
        }

        public async Task<GetEmployeeDto> GetEmployee(int employeeId)
        {
            var employee = await employeeRepository.GetAsync(employeeId);
            return typeAdapter.Adapt<GetEmployeeDto>(employee);
        }

        public async Task<PagedResult<GetEmployeeDto>> ListEmployees(PagingFilter pageFilter)
        {
            var employees = await employeeRepository.FindAsync(pageFilter.GetPagination());
            var page = typeAdapter.Adapt<List<GetEmployeeDto>>(employees);

            return PagedResult.FromList(page, employees.PageCount, employees.TotalCount);
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
