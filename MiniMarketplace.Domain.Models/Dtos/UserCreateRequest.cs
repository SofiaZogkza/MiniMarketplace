using System.Text.Json.Serialization;

namespace MiniMarketplace.Domain.Models.Dtos;

public record UserCreateRequest
{
    [JsonPropertyName("username")]

    public string Username { get; init; } = null!;
    [JsonPropertyName("email")] 

    public string Email { get; init; } = null!;
    [JsonPropertyName("password")] 

    public string PasswordHash { get; init; } = null!;
    [JsonPropertyName("first_name")] 

    public string? FirstName { get; init; }
    [JsonPropertyName("last_name")] 

    public string? LastName { get; init; }
}