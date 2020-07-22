using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ritter.Infra.Http.Filters
{
    public partial class HttpErrorFilterAttribute
    {
        public class InternalServerErrorObjectResult : ObjectResult
        {
            public InternalServerErrorObjectResult(object error) : base(error)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
