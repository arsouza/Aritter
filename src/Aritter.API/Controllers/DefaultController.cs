using Aritter.Presentation.WebApi.Core.Filters;
using System.Web.Mvc;

namespace Aritter.Presentation.WebApi.Controllers
{
    [AritterExceptionFilter]
    public abstract class DefaultController : Controller
    {
    }
}
