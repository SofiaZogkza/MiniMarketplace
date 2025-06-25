using MiniMarketplace.Domain.Models;
using MiniMarketplace.Persistence.Entities;

namespace MiniMarketplace.Persistence.Mappers;

public static class UserEntityMapper
{
    public static UserEntity ToEntity(User user)
    {
        return new UserEntity
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PasswordHash = user.PasswordHash,
            CreatedAt = DateTime.UtcNow        };
    }

    public static User ToDomain(UserEntity entity)
    {
        return new User
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            PasswordHash = entity.PasswordHash,
            CreatedAt = entity.CreatedAt
        };
    }
}