namespace Aritter.Application.DTO.Security
{
    public class AuthorizationDTO : DTO
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }
        public bool Allowed { get; set; }
        public bool Denied { get; set; }
        public PermissionDTO Permission { get; set; }
        public RoleDTO Role { get; set; }
    }
}