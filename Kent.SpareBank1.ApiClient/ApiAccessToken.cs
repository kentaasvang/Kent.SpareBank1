using System.Text.Json.Serialization;

namespace Kent.SpareBank1.ApiClient;

public class ApiAccessToken
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }
    
    [JsonPropertyName("token_type")]
    public required string TokenType { get; set; }
    
    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; set; }
    
    [JsonPropertyName("refresh_token")] 
    public required string RefreshToken { get; set; }
    
    [JsonPropertyName("refresh_token_expires_in")]
    public required int RefreshTokenExpiresIn { get; set; }
    
    [JsonPropertyName("refresh_token_absolute_expires_in")]
    public required int RefreshTokenAbsoluteExpiresIn { get; set; }
}