using Aritter.Domain.SecurityModule.Aggregates.Users.Specs;
using Aritter.Domain.Seedwork.Rules.Validation;
using Aritter.Domain.Seedwork.Rules.Validation.Common;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Validators
{
    public sealed class UserAccountValidator : EntityValidator<UserAccount>
    {
        public ValidationResult ValidateCredentials(UserAccount user, string password)
        {
            RemoveValidations();
            AddValidation("ValidCredentials", new ValidationRule<UserAccount>(UserAccountSpecs.HasValidCredentials(password), "Invalid username or password."));

            return Validate(user);
        }

        public ValidationResult ValidateAccount(UserAccount user)
        {
            RemoveValidations();
            AddValidation("UsernameRequired", new HasRequiredRule<UserAccount>(p => p.Username, "Username is required"));
            AddValidation("PasswordRequired", new HasRequiredRule<UserAccount>(p => p.Password, "Password is required"));
            AddValidation("EmailRequired", new HasRequiredRule<UserAccount>(p => p.Email, "Email is required"));

            return Validate(user);
        }

        public ValidationResult ValidateUserDuplicatated(UserAccount user)
        {
            RemoveValidations();
            AddValidation("DuplicatedUsername", new ValidationRule<UserAccount>(!UserAccountSpecs.HasUsername(user?.Username), "This username is not available"));
            AddValidation("DuplicatedEmail", new ValidationRule<UserAccount>(!UserAccountSpecs.HasEmail(user?.Email), "This e-mail is already registered"));

            return Validate(user);
        }
    }
}
