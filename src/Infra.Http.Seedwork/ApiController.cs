using Microsoft.AspNetCore.Mvc;
using System;

namespace Ritter.Infra.Http
{
    public abstract class ApiController : Controller
    {
        [NonAction]
        public virtual ObjectResult OkOrNotFound(object value)
        {
            if (value.IsNull())
                return NotFound(value);

            return Ok(value);
        }
    }
}
