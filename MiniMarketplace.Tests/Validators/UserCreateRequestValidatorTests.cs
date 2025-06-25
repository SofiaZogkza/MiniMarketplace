using FluentValidation.TestHelper;
using MiniMarketplace.Application.Common;
using MiniMarketplace.Application.Validators;
using MiniMarketplace.Tests.Builders;

namespace MiniMarketplace.Tests.Validators;

public class UserCreateRequestValidatorTests
{
    private readonly UserCreateRequestValidator _validator = new();
    private readonly UserCreateRequestBuilder _builder = new();

    [Fact]
    public void Valid_Request_Passes_All_Validations()
    {
        // Arrange
        var request = _builder.Build();

        // Act & Assert
        _validator.TestValidate(request)
            .ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(null, ValidationMessages.Required)]
    [InlineData("", ValidationMessages.MinLength3)]
    [InlineData("  ", ValidationMessages.Required)]
    [InlineData("ab", ValidationMessages.MinLength3)]
    public void Username_Validation_Fails_When_Invalid(string invalidUsername, string errorMessage)
    {
        var request = _builder.WithUsername(invalidUsername).Build();
        
        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Username)
            .WithErrorMessage(errorMessage);
    }

    [Theory]
    [InlineData(null, ValidationMessages.Required)]
    [InlineData("a", ValidationMessages.MinLength3)]
    [InlineData("ab", ValidationMessages.MinLength3)]
    public void FirstName_Validation_Fails_When_Empty(string invalidFirstName, string errorMessage)
    {
        var request = _builder.WithFirstName(invalidFirstName).Build();
        
        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.FirstName)
            .WithErrorMessage(errorMessage);
    }

    [Theory]
    [InlineData(null, ValidationMessages.Required)]
    [InlineData("a", ValidationMessages.MinLength3)]
    [InlineData("ab", ValidationMessages.MinLength3)]
    public void LastName_Validation_Fails_When_Too_Short(string invalidLastName, string errorMessage)
    {
        var request = _builder.WithLastName(invalidLastName).Build();
        
        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.LastName)
            .WithErrorMessage(errorMessage);
    }

    [Theory]
    [InlineData(null, ValidationMessages.Required)]
    [InlineData("missing-at.com", ValidationMessages.Invalid)]
    [InlineData("invalid@", ValidationMessages.Invalid)]
    [InlineData("@missing-local.com", ValidationMessages.Invalid)]
    public void Email_Validation_Fails_When_Invalid(string invalidEmail, string errorMessage)
    {
        var request = _builder.WithEmail(invalidEmail).Build();
        
        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage(errorMessage);
    }

    [Theory]
    [InlineData(null, ValidationMessages.Required)]
    [InlineData("", ValidationMessages.MinLength6)]
    [InlineData("12345", ValidationMessages.MinLength6)]
    public void Password_Validation_Fails_When_Invalid(string invalidPassword, string errorMessage)
    {
        var request = _builder.WithPassword(invalidPassword).Build();
        
        _validator.TestValidate(request)
            .ShouldHaveValidationErrorFor(x => x.PasswordHash)
            .WithErrorMessage(errorMessage);
    }
}