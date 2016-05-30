namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public static class UserFactory
    {
        public static User CreateUser(string userName, string firstName, string lastName, string email)
        {
            var user = new User(userName, firstName, lastName, email);

            user.GenerateIdentity();
            user.Enable();

            return user;
        }

        public static PreviousUserCredential CreatePreviousCredential(User user, UserCredential credential)
        {
            var previousCredential = new PreviousUserCredential(user, credential);
            previousCredential.GenerateIdentity();

            return previousCredential;
        }

        public static UserCredential CreateCredential(User user, string passwordHash)
        {
            var credential = new UserCredential(user, passwordHash);
            credential.GenerateIdentity();

            return credential;
        }
    }
}
