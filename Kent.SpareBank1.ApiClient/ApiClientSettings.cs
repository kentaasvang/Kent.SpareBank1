namespace Kent.SpareBank1.ApiClient;

public class ApiClientSettings
{
    public required Uri RedirectUri { get; set; }
    public required Uri ApiAuthorizationUri { get; set; }
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public required string AuthorizationCode { get; set; }
}