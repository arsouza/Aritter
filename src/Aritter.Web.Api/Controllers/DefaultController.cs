using Aritter.Web.Api.Core.Filters;
using System.Web.Mvc;

namespace Aritter.Web.Api.Controllers
{
    [AritterExceptionFilter]
    public abstract class DefaultController : Controller
    {
    }
}
