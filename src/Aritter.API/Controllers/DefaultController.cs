using Aritter.API.Core.Filters;
using System.Web.Mvc;

namespace Aritter.API.Controllers
{
    [AritterExceptionFilter]
    public abstract class DefaultController : Controller
    {
    }
}
