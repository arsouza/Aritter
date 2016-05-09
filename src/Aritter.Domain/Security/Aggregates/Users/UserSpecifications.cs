using System;
using Aritter.Domain.Seedwork.Specifications;

namespace Aritter.Domain.Security.Aggregates.Users
{
    public static class UsersSpecifications
    {
        public static ISpecification<User> FindByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            return new DirectSpecification<User>(u => u.UserName == userName && u.IsActive);
        }
    }
}
