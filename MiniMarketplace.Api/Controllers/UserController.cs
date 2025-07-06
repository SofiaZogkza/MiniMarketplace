using Microsoft.AspNetCore.Mvc;
using MiniMarketplace.Api.Contracts;
using MiniMarketplace.Application;
using MiniMarketplace.Domain.Models.Dtos;
using MiniMarketplace.Domain.Models.Errors;

namespace MiniMarketplace.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<UserResponse>>> GetUsers()
    {
        var response = await _userService.GetAllUsersAsync();
        
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserResponse>> GetUserById(string id)
    {
        if (!IsValidGuid(id, out var userId))
        {
            return BadRequest(new ErrorResponse { Code = ErrorCodes.InvalidRequest, Message = ErrorMessages.InvalidGuid });
        }
        
        var response = await _userService.FindAsync(userId);
        
        if (response is null)
        {
            return NotFound(new ErrorResponse { Code = ErrorCodes.UserNotFound, Message = ErrorMessages.NotFound });
        }

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserResponse>> Post(UserCreateRequest request)
    {
        if (request is null)
        {
            return BadRequest(new ErrorResponse { Code = ErrorCodes.InvalidRequest, Message = ErrorMessages.InvalidRequest });
        }
        
        var (emailExists, usernameExists) = await _userService.CheckEmailAndUsernameExistAsync(request.Email, request.Username);

        if (emailExists || usernameExists)
        {
            return BadRequest(new ErrorResponse { Code = ErrorCodes.RegistrationFailed, Message = ErrorMessages.RegistrationFailed });
        }

        var response = await _userService.CreateUserAsync(request);

        return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
    }
    
    public static bool IsValidGuid(string value, out Guid guid) =>
        Guid.TryParse(value, out guid) && guid != Guid.Empty;
}