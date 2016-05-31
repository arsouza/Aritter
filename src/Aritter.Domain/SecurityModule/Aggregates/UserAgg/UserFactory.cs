namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public static class UserFactory
    {
        public static User CreateUser(string userName, string password, string firstName, string lastName, string email)
        {
            var user = new User(userName, firstName, lastName, email);
            user.ChangePassword(password);
            user.Enable();

            return user;
        }

        internal static UserCredential CreateCredential(User user, string passwordHash)
        {
            var credential = new UserCredential(user, passwordHash);
            credential.Enable();

            return credential;
        }
    }
}
