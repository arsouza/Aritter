using System.Web;

namespace Aritter.Web.Core.Wrappers
{
	public class SessionWrapper
	{
		#region Methods

		public static void Clear()
		{
			HttpContext.Current.Session.Clear();
			HttpContext.Current.Session.Abandon();
		}

		public static object GetObject(string sessionName)
		{
			return HttpContext.Current.Session[sessionName];
		}

		public static T GetObject<T>(string sessionName)
		{
			var obj = GetObject(sessionName);

			if (obj != null)
				return (T)obj;

			return default(T);
		}

		public static void SetObject(string sessionKey, object value)
		{
			HttpContext.Current.Session[sessionKey] = null;
			HttpContext.Current.Session[sessionKey] = value;
		}

		#endregion Methods
	}
}