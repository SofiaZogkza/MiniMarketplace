using FluentValidation;
using MiniMarketplace.Application.Common;
using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application.Validators;

public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateRequestValidator()
    {
        RuleFor(x => x.Username)
            .MinimumLength(3).WithMessage(ValidationMessages.MinLengthMessage(3))
            .When(x => !string.IsNullOrEmpty(x.Username));

        RuleFor(x => x.FirstName)
            .MinimumLength(3).WithMessage(ValidationMessages.MinLengthMessage(3))
            .When(x => !string.IsNullOrEmpty(x.FirstName));

        RuleFor(x => x.LastName)
            .MinimumLength(3).WithMessage(ValidationMessages.MinLengthMessage(3))
            .When(x => !string.IsNullOrEmpty(x.LastName));

        RuleFor(x => x.Email)
            .Matches(@"^[^@\s]+@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*\.[A-Za-z]{2,}$") // No spaces, must have domain and TLD
            .WithMessage(ValidationMessages.Invalid)
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.PasswordHash)
            .MinimumLength(6).WithMessage(ValidationMessages.MinLengthMessage(6))
            .When(x => !string.IsNullOrEmpty(x.PasswordHash));
    }
}