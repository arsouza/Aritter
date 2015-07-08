using System.ComponentModel.DataAnnotations;

namespace Aritter.Manager.Web.Models
{
	public class ForgotPasswordViewModel
	{
		[Display(Name = "Email"), DataType(DataType.EmailAddress)]
		public string MailAddress { get; set; }
	}
}