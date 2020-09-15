using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Crosscutting.Collections;
using Ritter.Infra.Http.Controllers.Results;

namespace Ritter.Infra.Http.Controllers
{
    public class OkPagedCollectionResult : OkObjectResult
    {
        public OkPagedCollectionResult(IPagedCollection value)
            : base(new PagedResponse(value))
        {
        }
    }
}
