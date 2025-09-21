using System.Text.Json.Serialization;

namespace MiniMarketplace.Domain.Models.Dtos;

public class UserUpdateRequest
{
    [JsonPropertyName("username")]
    public string? Username { get; init; }
    [JsonPropertyName("email")] 
    public string? Email { get; init; }
    [JsonPropertyName("password")] 
    public string? PasswordHash { get; init; }
    [JsonPropertyName("first_name")] 
    public string? FirstName { get; init; }
    [JsonPropertyName("last_name")] 
    public string? LastName { get; init; }
}