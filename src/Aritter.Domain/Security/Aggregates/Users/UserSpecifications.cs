using Aritter.Domain.Seedwork.Specifications;
using System;

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
