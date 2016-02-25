using Aritter.Domain.Seedwork.Specification;
using System;

namespace Aritter.Domain.Aggregates.Security
{
    public static class UsersSpecifications
    {
        public static ISpecification<User> UserByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            return new DirectSpecification<User>(o => o.UserName == userName);
        }
    }
}
