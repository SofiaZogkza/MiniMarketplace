using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application.Mappers;

public static class UserMapper
{
    public static Domain.Models.User ToDomain(UserCreateRequest request)
    {
        return new Domain.Models.User
        {
            Username = request.Username,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PasswordHash = request.PasswordHash
        };
    }

    public static UserResponse ToResponse(Domain.Models.User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}