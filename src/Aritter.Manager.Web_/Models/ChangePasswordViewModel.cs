using System.ComponentModel.DataAnnotations;

namespace Aritter.Manager.Web.Models
{
	public class ChangePasswordViewModel
	{
		public int UserId { get; set; }
		public string UserName { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "Senha atual")]
		public string CurrentPassword { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "Nova senha")]
		public string NewPassword { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "Confirme a senha")]
		public string ConfirmNewPassword { get; set; }
	}
}