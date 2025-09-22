using FluentValidation.TestHelper;
using MiniMarketplace.Application.Common;
using MiniMarketplace.Application.Validators;
using MiniMarketplace.Tests.Builders;

namespace MiniMarketplace.Tests.Validators;

public class UserUpdateRequestValidatorTests
{
    private readonly UserUpdateRequestValidator _validator = new();
    private readonly UserUpdateRequestBuilder _builder = new();

    [Fact]
    public void When_All_Properties_Are_Valid_Should_Pass_Validation()
    {
        // Arrange
        var request = _builder.Build();

        // Act & Assert
        _validator.TestValidate(request).ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(" ", ValidationMessages.MinLength3)]
    [InlineData("ab", ValidationMessages.MinLength3)]
    public void When_Username_Is_LessThan_3Characters_Should_Fail_Validation(string invalidUsername,
        string errorMessage)
    {
        //Arrange
        var request = _builder.WithUsername(invalidUsername).Build();

        // Act
        _validator.TestValidate(request).ShouldHaveValidationErrorFor(x => x.Username).WithErrorMessage(errorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void When_Username_Is_Null_Or_Empty_Should_Pass_Validation(string emptyUsername)
    {
        //Arrange
        var request = _builder.WithUsername(emptyUsername).Build();

        // Act
        _validator.TestValidate(request).ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(" ", ValidationMessages.MinLength3)]
    [InlineData("ab", ValidationMessages.MinLength3)]
    public void When_Firstname_Is_LessThan_3Characters_Should_Fail_Validation(string invalidFirstname,
        string errorMessage)
    {
        //Arrange
        var request = _builder.WithFirstname(invalidFirstname).Build();

        // Act
        _validator.TestValidate(request).ShouldHaveValidationErrorFor(x => x.FirstName).WithErrorMessage(errorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void When_Firstname_Is_Null_Or_Empty_Should_Pass_Validation(string emptyFirstname)
    {
        //Arrange
        var request = _builder.WithFirstname(emptyFirstname).Build();

        // Act
        _validator.TestValidate(request).ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(" ", ValidationMessages.MinLength3)]
    [InlineData("ab", ValidationMessages.MinLength3)]
    public void When_Lastname_Is_LessThan_3Characters_Should_Fail_Validation(string invalidLastname,
        string errorMessage)
    {
        // Arrange
        var request = _builder.WithLastname(invalidLastname).Build();

        // Act
        _validator.TestValidate(request).ShouldHaveValidationErrorFor(x => x.LastName).WithErrorMessage(errorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void When_Lastname_Is_Null_Or_Empty_Should_Pass_Validation(string emptyLastname)
    {
        //Arrange
        var request = _builder.WithLastname(emptyLastname).Build();

        // Act
        _validator.TestValidate(request).ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData("sofia@yahoo.com")]
    [InlineData("sofia1@for.com")]
    [InlineData("user.name+tag+sorting@example.com")]
    [InlineData("user_name@example.co.uk")]
    public void When_Email_Is_Valid_Should_Pass_Validation(string validEmail)
    {
        var request = _builder.WithEmail(validEmail).Build();
        _validator.TestValidate(request).ShouldNotHaveValidationErrorFor(x => x.Email);
    }

    [Theory]
    [InlineData("plainaddress")]
    [InlineData("@missingusername.com")]
    [InlineData("username@")]
    [InlineData("username@.com")]
    [InlineData("username@com")]
    [InlineData("user name@example.com")]
    [InlineData("username@exam!ple.com")]
    public void When_Email_Is_Invalid_Should_Fail_Validation(string invalidEmail)
    {
        // Arrange
        var request = _builder.WithEmail(invalidEmail).Build();
        
        // Act & Assert
        _validator.TestValidate(request).ShouldHaveValidationErrorFor(x => x.Email)
            .WithErrorMessage(ValidationMessages.Invalid);
    }

    [Theory]
    [InlineData("*&^%", ValidationMessages.MinLength6)]
    [InlineData("1234", ValidationMessages.MinLength6)]
    [InlineData(" ", ValidationMessages.MinLength6)]
    public void When_PasswordHash_Is_Invalid_Should_Fail_Validation(string invalidPassword, string errorMessage)
    {
        var request = _builder.WithPassword(invalidPassword).Build();
        _validator.TestValidate(request).ShouldHaveValidationErrorFor(x => x.PasswordHash)
            .WithErrorMessage(errorMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("&*^%JHGF765")]
    public void When_PasswordHash_Is_Valid_Should_Pass_Validation(string validPassword)
    {
        var request = _builder.WithPassword(validPassword).Build();
        _validator.TestValidate(request).ShouldNotHaveAnyValidationErrors();
    }
}