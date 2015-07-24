using Aritter.Infrastructure.Resources;
using System.ComponentModel.DataAnnotations;

namespace Aritter.Web.Models
{
	public class ChangePasswordViewModel
	{
		public int UserId { get; set; }
		public string UserName { get; set; }

		[Required, DataType(DataType.Password), Display(ResourceType = typeof(Global), Name = "ChangePasswordViewModel_CurrentPassword")]
		public string CurrentPassword { get; set; }

		[Required, DataType(DataType.Password), Display(ResourceType = typeof(Global), Name = "ChangePasswordViewModel_NewPassword")]
		public string NewPassword { get; set; }

		[Required, DataType(DataType.Password), Display(ResourceType = typeof(Global), Name = "ChangePasswordViewModel_ConfirmNewPassword")]
		public string ConfirmNewPassword { get; set; }
	}
}