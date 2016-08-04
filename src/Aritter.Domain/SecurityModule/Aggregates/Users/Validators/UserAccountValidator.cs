using Aritter.Domain.Common.Specs;
using Aritter.Domain.SecurityModule.Aggregates.Users.Specs;
using Aritter.Domain.Seedwork.Rules.Validation;

namespace Aritter.Domain.SecurityModule.Aggregates.Users.Validators
{
    public sealed class UserAccountValidator : EntityValidator<UserAccount>
    {
        public ValidationResult ValidateUserCredentials(UserAccount user, string password)
        {
            RemoveValidations();

            var spec = new ValidCredentialsSpec(password);
            AddValidation("ValidCredentials", new ValidationRule<UserAccount>(spec, "Invalid username or password."));

            return Validate(user);
        }

        public ValidationResult ValidateUserAccount(UserAccount user)
        {
            RemoveValidations();

            AddValidation("UsernameRequired", new ValidationRule<UserAccount>(new RequiredPropertySpec<UserAccount>().Property(p => p.Username), "Username is required"));
            AddValidation("PasswordRequired", new ValidationRule<UserAccount>(new RequiredPropertySpec<UserAccount>().Property(p => p.Password), "Password is required"));
            AddValidation("EmailRequired", new ValidationRule<UserAccount>(new RequiredPropertySpec<UserAccount>().Property(p => p.Email), "Email is required"));

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
