using MiniMarketplace.Domain.Models;
using MiniMarketplace.Domain.Models.Dtos;

namespace MiniMarketplace.Application.Mappers;

public interface IUserMapper
{
    User ToDomain(UserCreateRequest request);
    UserResponse ToResponse(User user);
}