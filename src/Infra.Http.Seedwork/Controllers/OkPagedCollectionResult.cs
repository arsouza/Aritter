using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Http.Controllers.Results;

namespace Ritter.Infra.Http.Seedwork.Controllers
{
    public class OkPagedCollectionResult : OkObjectResult
    {
        public OkPagedCollectionResult(IPagedCollection value)
            : base(new PagedResponse(value))
        {
        }
    }
}
