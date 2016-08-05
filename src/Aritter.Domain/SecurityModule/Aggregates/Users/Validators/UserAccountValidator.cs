using Aritter.Domain.SecurityModule.Aggregates.Users.Specs;
using Aritter.Domain.Seedwork.Rules.Validation;
using Aritter.Domain.Seedwork.Rules.Validation.Common;
using Aritter.Domain.Seedwork.Specifications;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Validators
{
    public sealed class UserAccountValidator : EntityValidator<UserAccount>
    {
        public ValidationResult ValidateUserCredentials(UserAccount user, string password)
        {
            RemoveValidations();
            AddValidation("ValidCredentials", new ValidationRule<UserAccount>(new IsNotNullSpec<UserAccount>() & new ValidCredentialsSpec(password), "Invalid username or password."));

            return Validate(user);
        }

        public ValidationResult ValidateUserAccount(UserAccount user)
        {
            RemoveValidations();
            AddValidation("UsernameRequired", new RequiredPropertyRule<UserAccount>(p => p.Username, "Username is required"));
            AddValidation("PasswordRequired", new RequiredPropertyRule<UserAccount>(p => p.Password, "Password is required"));
            AddValidation("EmailRequired", new RequiredPropertyRule<UserAccount>(p => p.Email, "Email is required"));

            return Validate(user);
        }

        public ValidationResult ValidateUserDuplicatated(UserAccount user)
        {
            RemoveValidations();
            AddValidation("DuplicatedUsername", new ValidationRule<UserAccount>(new IsNotNullSpec<UserAccount>() & !new UsernameEqualsSpec(user?.Username), "This username is not available"));
            AddValidation("DuplicatedEmail", new ValidationRule<UserAccount>(new IsNotNullSpec<UserAccount>() & !new EmailEqualsSpec(user?.Email), "This e-mail is already registered"));

            return Validate(user);
        }
    }
}
