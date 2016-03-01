namespace Aritter.Application.DTO.Security
{
    public class RoleMenuDTO : DTO
    {
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        public MenuDTO Menu { get; set; }
    }
}
