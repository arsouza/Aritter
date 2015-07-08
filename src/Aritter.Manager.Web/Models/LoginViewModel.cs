using System.ComponentModel.DataAnnotations;

namespace Aritter.Manager.Web.Models
{
	public class LoginViewModel
	{
		[Required, Display(Name = "Usuário")]
		public string Username { get; set; }

		[Required, DataType(DataType.Password), Display(Name = "Senha")]
		public string Password { get; set; }

		[Required, Display(Name = "Continuar conectado")]
		public bool RememberMe { get; set; }
	}
}