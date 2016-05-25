namespace Aritter.Application.Seedwork.SecurityModule.Messages.Users
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
    }
}
