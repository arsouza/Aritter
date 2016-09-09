namespace Aritter.Application.DTO.SecurityModule
{
    public class UpdateUserDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool Enabled { get; set; }
    }
}
