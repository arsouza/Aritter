using Aritter.Infrastructure.Resources;
using System.ComponentModel.DataAnnotations;

namespace Aritter.Web.Models
{
	public class ForgotPasswordViewModel
	{
		[Display(ResourceType = typeof(Global), Name = "ForgotPasswordViewModel_MailAddress"), DataType(DataType.EmailAddress)]
		public string MailAddress { get; set; }
	}
}