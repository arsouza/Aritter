using Microsoft.AspNetCore.Mvc;
using Ritter.Application.Models;
using Ritter.Infra.Http;
using Ritter.Samples.Application.DTO.Employees.Response;
using Ritter.Samples.Application.Services.Employees;
using System.Net;
using System.Threading.Tasks;

namespace Ritter.Samples.Web.Controllers
{
    /// <summary>
    /// Everything about Employees
    /// </summary>
    [Route("api/[controller]")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeAppService employeeAppService;

        public EmployeesController(IEmployeeAppService employeeAppService)
        {
            this.employeeAppService = employeeAppService;
        }

        /// <summary>
        /// List all employees
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/employees?pageIndex=0&amp;pageSize=10&amp;orderByName=FirstName&amp;ascending=true
        ///
        /// </remarks>
        /// <param name="pageFilter">Page filter</param>
        /// <returns>A list of employees</returns>
        /// <response code="200">If the search has sucesss</response> 
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<GetEmployeeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(PagingFilter pageFilter) => Ok(await employeeAppService.ListEmployees(pageFilter));
    }
}
