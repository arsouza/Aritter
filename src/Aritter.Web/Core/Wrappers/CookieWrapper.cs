using Aritter.Infrastructure.Encryption;
using Aritter.Infrastructure.Serialization;
using System;
using System.Web;

namespace Aritter.Web.Core.Wrappers
{
	public static class CookieWrapper
	{
		#region Methods

		public static void AddCookie(string name, object value, double expirationTime = 2880)
		{
			var data = Serialize.ToBase64String(value);
			data = Encrypter.Encrypt(data);

			var cookie = new HttpCookie(name)
			{
				Value = data,
				Expires = DateTime.Now + TimeSpan.FromMinutes(expirationTime)
			};

			HttpContext.Current.Response.Cookies.Add(cookie);
		}

		public static HttpCookie GetCookie(string name)
		{
			return HttpContext.Current.Request.Cookies[name];
		}

		public static T GetCookie<T>(string name)
		{
			var cookie = HttpContext.Current.Request.Cookies[name];

			if (cookie == null)
				return default(T);

			var value = cookie.Value;
			value = Encrypter.Decrypt(value);

			return Serialize.FromBase64String<T>(value);
		}

		public static void RemoveCookie(string name)
		{
			if (HttpContext.Current.Request.Cookies[name] != null)
			{
				var cookie = new HttpCookie(name)
				{
					Expires = DateTime.Now.AddDays(-1d)
				};

				HttpContext.Current.Response.Cookies.Add(cookie);
			}
		}

		public static void RenewCookie(string cookieName, DateTime? expires = null)
		{
			var cookie = GetCookie(cookieName);
			cookie.Expires = expires ?? DateTime.Now.AddDays(1d);

			RemoveCookie(cookieName);
			HttpContext.Current.Response.Cookies.Add(cookie);
		}

		#endregion Methods
	}
}