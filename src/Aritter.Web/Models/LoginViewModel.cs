using Aritter.Infra.CrossCutting.Resources;
using System.ComponentModel.DataAnnotations;

namespace Aritter.Web.Models
{
	public class LoginViewModel
	{
		[Required, Display(ResourceType = typeof(Global), Name = "LoginViewModel_Username")]
		public string Username { get; set; }

		[Required, DataType(DataType.Password), Display(ResourceType = typeof(Global), Name = "LoginViewModel_Password_Senha")]
		public string Password { get; set; }

		[Required, Display(ResourceType = typeof(Global), Name = "LoginViewModel_RememberMe_Continuar_conectado")]
		public bool RememberMe { get; set; }
	}
}