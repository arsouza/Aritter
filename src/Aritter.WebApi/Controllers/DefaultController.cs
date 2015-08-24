using Aritter.WebApi.Core.Filters;
using System.Web.Mvc;

namespace Aritter.WebApi.Controllers
{
    [AritterExceptionFilter]
    public abstract class DefaultController : Controller
    {
    }
}
