namespace Aritter.Application.DTO.SecurityModule
{
    public class UpdateUserAccountDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool Enabled { get; set; }
    }
}
