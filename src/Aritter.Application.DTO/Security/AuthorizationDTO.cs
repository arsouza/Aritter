namespace Aritter.Application.DTO.Security
{
	public class AuthorizationDTO : DTO
	{
		public bool Allowed { get; set; }
		public bool Denied { get; set; }
		public virtual PermissionDTO Permission { get; set; }
		public virtual RoleDTO Role { get; set; }
	}
}