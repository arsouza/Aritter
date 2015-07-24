using System.Web.Mvc;

namespace Aritter.Web.Core.Extensions
{
	public static partial class ExtensionManager
	{
		public static MvcHtmlString If(this MvcHtmlString value, bool evaluation)
		{
			return evaluation ? value : MvcHtmlString.Empty;
		}
	}
}