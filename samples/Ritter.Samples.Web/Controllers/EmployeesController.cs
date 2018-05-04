using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Crosscutting;
using Ritter.Samples.Application.DTO.Base;
using Ritter.Samples.Application.DTO.Employees.Response;
using Ritter.Samples.Application.Services.Employees;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Ritter.Samples.Web.Controllers
{
    /// <summary>
    /// Everything about Employees
    /// </summary>
    [Route("api/[controller]")]
    public class EmployeesController : Controller
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
        ///     GET /api/employees?PageIndex=0&PageSize=10&OrderByName=FirstName&Ascending=true
        ///
        /// </remarks>
        /// <param name="pageFilter">Page filter</param>
        /// <returns>A list of employees</returns>
        /// <response code="200">If the search has sucesss</response> 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetEmployeeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(PageFilter pageFilter)
        {
            return Ok(await employeeAppService.ListEmployees(pageFilter));
        }
    }
}
