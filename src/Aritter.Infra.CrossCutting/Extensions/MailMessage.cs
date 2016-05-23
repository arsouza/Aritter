using System;
using System.Net.Mail;
using System.Net.Mime;

namespace Aritter.Infra.Crosscutting.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static void Attach(this MailMessage mailMessage, string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
				throw new ArgumentNullException(nameof(fileName));

			var attachment = new Attachment(fileName, MediaTypeNames.Application.Octet);
			mailMessage.Attachments.Add(attachment);
		}

		#endregion Methods
	}
}