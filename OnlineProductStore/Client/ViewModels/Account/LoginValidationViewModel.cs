using FluentValidation;

namespace OnlineProductStore.Client.ViewModels.Account
{
    public class LoginValidationViewModel : AbstractValidator<LoginViewModel>
    {
        public LoginValidationViewModel()
        {
            RuleFor(_ => _.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid Email");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Invalid Credentials")
                    .MinimumLength(6).WithMessage("Invalid Credentials")
                    .MaximumLength(16).WithMessage("Invalid Credentials");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result =
            await ValidateAsync(ValidationContext<LoginViewModel>.CreateWithOptions((LoginViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
