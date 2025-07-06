using MiniMarketplace.Application.Mappers;
using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserMapper _userMapper;

    public UserService(IUserRepository userRepository, IUserMapper userMapper)
    {
        _userRepository = userRepository;
        _userMapper = userMapper;
    }

    public async Task<List<UserResponse>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        var response = users.Select(_userMapper.ToResponse).ToList();
        return response;
    }

    public Task<UserResponse> FindAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<UserResponse> CreateUserAsync(UserCreateRequest request)
    {
        var user = _userMapper.ToDomain(request);
        
        var userCreated = await _userRepository.CreateUserAsync(user);
        
        var response = _userMapper.ToResponse(userCreated);
        
        return response;
    }

    public async Task<(bool emailExists, bool usernameExists)> CheckEmailAndUsernameExistAsync(string email, string username)
    {
        return await _userRepository.CheckEmailAndUsernameExistAsync(email, username);
    }
}