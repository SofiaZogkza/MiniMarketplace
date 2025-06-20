namespace MiniMarketplace.Domain.Models.Dtos;

public record UserResponse()
{
    public Guid Id { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
};