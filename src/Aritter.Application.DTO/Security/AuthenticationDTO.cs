using System;

namespace Aritter.Application.DTO.Security
{
	public class AuthenticationDTO : DTO
	{
		public string UserName { get; set; }
		public DateTime Date { get; set; }
		public AuthenticationState State { get; set; }
		public virtual UserDTO User { get; set; }
	}
}
