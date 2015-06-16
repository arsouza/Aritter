using Aritter.Manager.Infrastructure.Configuration;
using System.Net;
using System.Net.Mail;

namespace Aritter.Manager.Infrastructure.Mail
{
	public class MailClient : SmtpClient
	{
		public MailClient()
			: base()
		{
			this.LoadClientConfig();
		}

		private void LoadClientConfig()
		{
			var mailConfig = ApplicationSettings.Mail;

			this.Host = mailConfig.Host;
			this.EnableSsl = mailConfig.EnableSsl;
			this.Port = mailConfig.Port;
			this.UseDefaultCredentials = mailConfig.UseDefaultCredentials;

			this.Credentials = new NetworkCredential(mailConfig.UserName, mailConfig.Password);
		}
	}
}
