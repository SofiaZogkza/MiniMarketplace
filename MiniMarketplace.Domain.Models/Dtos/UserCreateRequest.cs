namespace MiniMarketplace.Domain.Models.Dtos;

public record UserCreateRequest
{
    public string Username { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PasswordHash { get; init; } = null!;
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow; // TODO Search if it is ok to steup here or code or DB
}