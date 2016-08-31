namespace Aritter.Application.DTO.SecurityModule
{
    public class AuthorizationDto
    {
        public string UserRole { get; set; }
        public bool Allowed { get; set; }
        public bool Denied { get; set; }
    }
}
