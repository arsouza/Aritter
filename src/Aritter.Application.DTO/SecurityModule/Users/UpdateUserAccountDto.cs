namespace Aritter.Application.DTO.SecurityModule.Users
{
    public class UpdateUserAccountDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool Enabled { get; set; }
    }
}
