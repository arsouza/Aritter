using System;
using System.Net.Mail;
using System.Net.Mime;

namespace Aritter.Infrastructure.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static void Attach(this MailMessage mailMessage, string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new ArgumentNullException("fileName");

			var attachment = new Attachment(fileName, MediaTypeNames.Application.Octet);
			mailMessage.Attachments.Add(attachment);
		}

		#endregion Methods
	}
}