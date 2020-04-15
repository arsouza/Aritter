using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Crosscutting;

namespace Ritter.Infra.Http.Controllers
{
    public class ApiController : ControllerBase
    {
        protected virtual OkPagedCollectionResult Paged(IPagedCollection collection)
        {
            return new OkPagedCollectionResult(collection);
        }

        protected virtual IActionResult OkOrNotFound(object value, string message)
        {
            if (value is null)
            {
                return NotFound(message);
            }

            return Ok(value);
        }

        protected virtual IActionResult OkOrNotFound(object value)
        {
            if (value is null)
            {
                return NotFound();
            }

            return Ok(value);
        }

        protected virtual ActionResult<T> OkOrNotFound<T>(T value, string message)
        {
            if (value is null)
            {
                return NotFound(message);
            }

            return Ok(value);
        }

        protected virtual ActionResult<T> OkOrNotFound<T>(T value)
        {
            if (value is null)
            {
                return NotFound();
            }

            return Ok(value);
        }
    }
}
