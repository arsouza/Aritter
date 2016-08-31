namespace Aritter.Domain.SecurityModule.Aggregates
{
    public static class UserFactory
    {
        public static UserAccount CreateAccount(string username, string email, string password)
        {
            var user = new UserAccount(username, email);
            user.ChangePassword(password);
            user.HasValidLoginAttempt();

            return user;
        }

        public static UserAccount CreateAccount(string username, string email, string password, UserProfile profile)
        {
            var user = CreateAccount(username, email, password);
            user.SetProfile(profile);

            return user;
        }
    }
}
