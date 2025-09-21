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
    public void AllPropertiesMustBeValid()
    {
        // Arrange
        var request = _builder.Build();

        // Act & Assert
        _validator.TestValidate(request)
            .ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(null, ValidationMessages.MinLength3)]
    [InlineData("", ValidationMessages.MinLength3)]
    [InlineData("   ", ValidationMessages.MinLength3)]
    [InlineData("ab", ValidationMessages.MinLength3)]
    public void UsernameIsRequired(string invalidUsername, string errorMessage)
    {
        //Arrange
        var request = _builder.WithInvalidUsername(invalidUsername).Build();
        
        // Act
        _validator.TestValidate(request).ShouldHaveValidationErrorFor(x => x.Username).WithErrorMessage(errorMessage);
    }
}