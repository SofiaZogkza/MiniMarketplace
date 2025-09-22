using FluentValidation;
using MiniMarketplace.Application.Common;
using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application.Validators;

public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
{
    public UserCreateRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage(ValidationMessages.Required)
            .MinimumLength(3).WithMessage(ValidationMessages.MinLengthMessage(3));
        
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage(ValidationMessages.Required)
            .MinimumLength(3).WithMessage(ValidationMessages.MinLengthMessage(3));

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage(ValidationMessages.Required)
            .MinimumLength(3).WithMessage(ValidationMessages.MinLengthMessage(3));
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(ValidationMessages.Required)
            .MinimumLength(6).WithMessage(ValidationMessages.MinLength6)
            .Matches(@"^[^@\s]+@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*\.[A-Za-z]{2,}$").WithMessage(ValidationMessages.Invalid);
        
        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage(ValidationMessages.Required)
            .MinimumLength(6).WithMessage(ValidationMessages.MinLengthMessage(6));
    }
}