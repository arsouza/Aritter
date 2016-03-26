using System;

namespace Aritter.Application.DTO.Security
{
	public class UserPasswordDTO : DTO
	{
		public string PasswordHash { get; set; }
		public DateTime Date { get; set; }
		public UserDTO User { get; set; }
	}
}
