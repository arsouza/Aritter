using Aritter.Domain.Seedwork.Specs;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions.Specs
{
    public static class UserAssignmentSpecs
    {
        public static Specification<UserAssignment> HasUserAccountId(int userAccountId)
        {
            return new DirectSpecification<UserAssignment>(p => p.UserAccountId == userAccountId);
        }
    }
}
