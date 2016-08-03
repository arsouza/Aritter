using System.ComponentModel.DataAnnotations;

namespace Aritter.Application.DTO.SecurityModule.Users
{
	public class AddUserDto
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
