namespace Aritter.Application.DTO.Security
{
    public class UserRoleDTO : DTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        public UserDTO User { get; set; }
    }
}
