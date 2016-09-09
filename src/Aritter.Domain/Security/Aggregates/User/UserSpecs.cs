using Aritter.Domain.Seedwork.Specs;

namespace Aritter.Domain.Security.Aggregates.Specs
{
    public static class UserSpecs
    {
        public static Specification<User> HasEmail(string email)
        {
            return new DirectSpecification<User>(p => p.Email == email);
        }

        public static Specification<User> HasUsername(string username)
        {
            return new DirectSpecification<User>(p => p.Username == username);
        }
    }
}
