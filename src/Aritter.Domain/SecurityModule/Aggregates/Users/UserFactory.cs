namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public static class UserFactory
    {
        public static UserAccount CreateAccount(string username, string password, string email)
        {
            var user = new UserAccount(username, email);
            user.ChangePassword(password);

            return user;
        }

        public static UserAccount CreateAccount(string username, string password, string email, UserProfile profile)
        {
            var user = new UserAccount(username, email, profile);
            user.ChangePassword(password);

            return user;
        }

        public static UserProfile CreateProfile(string name)
        {
            return new UserProfile(name);
        }
    }
}
