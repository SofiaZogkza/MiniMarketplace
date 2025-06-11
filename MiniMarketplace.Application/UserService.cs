using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<List<UserResponse>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> FindAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> CreateUserAsync(UserCreateRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool emailExists, bool usernameExists)> CheckEmailAndUsernameExistAsync(string email, string username)
    {
        return await _userRepository.CheckEmailAndUsernameExistAsync(email, username);
    }
}