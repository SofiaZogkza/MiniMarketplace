using Microsoft.AspNetCore.Mvc;
using MiniMarketplace.Api.Contracts;
using MiniMarketplace.Api.Controllers;
using MiniMarketplace.Application;
using MiniMarketplace.Domain.Models.Errors;
using MiniMarketplace.Tests.Builders;
using Moq;

namespace MiniMarketplace.Tests;

public class UserControllerTest
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly UserController _controller;
    private readonly UserCreateRequestBuilder _builder;

    public UserControllerTest()
    {
        _mockUserService = new Mock<IUserService>();
        _controller = new UserController(_mockUserService.Object);
        _builder = new UserCreateRequestBuilder();
    }

    #region CreateUser

    [Fact]
    public async Task CreateUser_WithValidData_ShouldCreateUser()
    {
        var createRequest = _builder.Build();

        var createdUser = new UserResponse()
        {
            Id = "25bac0a1-71f3-4522-91e9-3d8415b7d2b1",
            FirstName = createRequest.FirstName,
            LastName = createRequest.LastName,
            Email = createRequest.Email,
            Username = createRequest.Username
        };
        
        _mockUserService.Setup(s => s.CheckEmailAndUsernameExistAsync(createRequest.Email, createRequest.Username))
            .ReturnsAsync((false, false));
        _mockUserService.Setup(s => s.CreateUserAsync(createRequest))
            .ReturnsAsync(createdUser);
        
        // Act
        var result = await _controller.Post(createRequest);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnValue = Assert.IsType<UserResponse>(actionResult.Value);
        Assert.Equal(createdUser.Username, returnValue.Username);
        Assert.Equal(createdUser.Email, returnValue.Email);
    }
    
    [Fact]
    public async Task CreateUser_WithExistingEmailOrUsername_ShouldReturnBadRequest()
    {
        // Arrange
        var userRequest = _builder.Build();
        _mockUserService.Setup(s => s.CheckEmailAndUsernameExistAsync(userRequest.Email, userRequest.Username))
            .ReturnsAsync((true, false)); // Email exists

        // Act
        var result = await _controller.Post(userRequest);

        // Assert
        var actionResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        var error = Assert.IsType<ErrorResponse>(actionResult.Value);
        Assert.Equal(ErrorCodes.RegistrationFailed, error.Code);
        Assert.Equal(ErrorMessages.RegistrationFailed, error.Message);
    }
    
    [Fact]
    public async Task CreateUser_WithNullRequest_ShouldReturnBadRequest()
    {
        // Act
        var result = await _controller.Post(null);

        // Assert
        var actionResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        var error = Assert.IsType<ErrorResponse>(actionResult.Value);
        Assert.Equal(ErrorCodes.InvalidRequest, error.Code);
        Assert.Equal(ErrorMessages.InvalidRequest, error.Message);
    }
    
    #endregion
}