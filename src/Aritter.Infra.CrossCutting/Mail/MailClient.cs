using Aritter.Infra.Configuration;
using System.Net;
using System.Net.Mail;

namespace Aritter.Infra.Crosscutting.Mail
{
	public class MailClient : SmtpClient
	{
		public MailClient()
		{
			LoadClientConfig();
		}

		private void LoadClientConfig()
		{
			var mailConfig = ApplicationSettings.Mail;

			Host = mailConfig.Host;
			EnableSsl = mailConfig.EnableSsl;
			Port = mailConfig.Port;
			UseDefaultCredentials = mailConfig.UseDefaultCredentials;

			Credentials = new NetworkCredential(mailConfig.UserName, mailConfig.Password);
		}
	}
}
