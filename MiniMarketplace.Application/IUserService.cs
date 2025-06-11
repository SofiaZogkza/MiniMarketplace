using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application;

public interface IUserService
{
    Task<List<UserResponse>> GetAllUsersAsync();
    Task<UserResponse> FindAsync(string userId);
    Task<UserResponse> CreateUserAsync(UserCreateRequest request);
    Task<(bool emailExists, bool usernameExists)> CheckEmailAndUsernameExistAsync(string email, string username);

}