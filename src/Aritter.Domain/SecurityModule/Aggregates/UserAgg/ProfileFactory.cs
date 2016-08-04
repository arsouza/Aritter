namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public class ProfileFactory
    {
        public static Profile CreateProfile(string firstName, string lastName)
        {
            return new Profile(firstName, lastName);
        }
    }
}
