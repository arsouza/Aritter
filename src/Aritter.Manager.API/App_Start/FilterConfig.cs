using System.Web;
using System.Web.Mvc;

namespace Aritter.Manager.API
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
