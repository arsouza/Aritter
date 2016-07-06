using Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs;
using Aritter.Domain.Seedwork.Rules.Validation;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Validators
{
    public sealed class UserValidator : EntityValidator<User>
    {
        public const string CredentialsValidation = "CredentialsValidation";
        public const string UserIsNotNullValidation = "UserIsNotNullValidation";

        public ValidationResult ValidateCredentials(User user, string password)
        {
            var spec = new UserHasValidCredentialsSpec(password);
            AddValidation(CredentialsValidation, new ValidationRule<User>(spec, "Invalid username or password."));

            return Validate(user, CredentialsValidation);
        }

        public ValidationResult ValidateUser(User user)
        {
            var spec = new UserIsNotNullSpec();
            AddValidation(UserIsNotNullValidation, new ValidationRule<User>(spec, "Invalid username or password."));

            return Validate(user, UserIsNotNullValidation);
        }
    }
}
