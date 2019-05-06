using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Http.Controllers.Results;

namespace Infra.Http.Seedwork.Controllers
{
    public class ApiController : ControllerBase
    {
        protected virtual IActionResult Paged(IPagedCollection collection)
        {
            return Ok(new PagedResult(collection));
        }

        protected virtual IActionResult Paged<T>(IPagedCollection<T> collection)
        {
            return Ok(new PagedResult<T>(collection));
        }

        protected virtual IActionResult OrOrNotFound(object value, string message)
        {
            if (value is null)
            {
                return NotFound(message);
            }

            return Ok(value);
        }

        protected virtual IActionResult OrOrNotFound(object value)
        {
            if (value is null)
            {
                return NotFound();
            }

            return Ok(value);
        }
    }
}
