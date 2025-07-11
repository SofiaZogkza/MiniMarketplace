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
    public async Task<ActionResult<List<UserResponse>>> GetUsers()
    {
        var response = await _userService.GetAllUsersAsync();
        if (response is null)
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> GetUserById(string id)
    {
        var response = await _userService.FindAsync(id);
        if (response is null)
        {
            return NotFound();
        }
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<UserResponse>> Post(UserCreateRequest request)
    {
        if (request is null)
        {
            return BadRequest(new ErrorResponse
            {
                Code = ErrorCodes.InvalidRequest,
                Message = ErrorMessages.InvalidRequest
            });
        }
        
        var (emailExists, usernameExists) = await _userService.CheckEmailAndUsernameExistAsync(request.Email, request.Username);

        if (emailExists || usernameExists)
        {
            return BadRequest(new ErrorResponse
            {
                Code = ErrorCodes.RegistrationFailed,
                Message = ErrorMessages.RegistrationFailed
            });
        }

        var response = await _userService.CreateUserAsync(request);

        return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
    }
}