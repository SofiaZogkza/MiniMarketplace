using System.Text.Json.Serialization;

public sealed record UserResponse
{
    [JsonPropertyName("id")]
    public string Id { get; init; }
    [JsonPropertyName("username")] 
    public string Username { get; init; }
    [JsonPropertyName("email")]
    public string Email { get; init; }
    [JsonPropertyName("first_name")]
    public string? FirstName { get; init; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; init; }
}