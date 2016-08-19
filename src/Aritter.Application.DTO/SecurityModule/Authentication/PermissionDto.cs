namespace Aritter.Application.DTO.SecurityModule.Authentication
{
    public class PermissionDto
    {
        public string Operation { get; set; }
        public string Resource { get; set; }
        public string Application { get; set; }
    }
}
