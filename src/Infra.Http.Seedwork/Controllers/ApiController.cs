using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Http.Responses;

namespace Infra.Http.Seedwork.Controllers
{
    public class ApiController : ControllerBase
    {
        protected virtual IActionResult Paged(IPagedCollection collection)
        {
            return Ok(new PagedResponse(collection));
        }

        protected virtual IActionResult Paged<T>(IPagedCollection<T> collection)
        {
            return Ok(new PagedResponse<T>(collection));
        }
    }
}
