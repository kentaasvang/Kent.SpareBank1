namespace Kent.SpareBank1.ApiClient.ConsoleUI;

internal class EnvironmentVariables
{
    public Uri RedirectUri { get; set; }
    public Uri AuthorizationUri { get; set; }
    public string ClientId { get; }
    public string ClientSecret { get; }
    public string AuthorizationCode { get; }
    
    public EnvironmentVariables
    (
        Uri redirectUri, 
        Uri authorizationUri, 
        string clientId, 
        string clientSecret, 
        string authorizationCode
    )
    {
        RedirectUri = redirectUri;
        AuthorizationUri = authorizationUri;
        ClientId = clientId;
        ClientSecret = clientSecret;
        AuthorizationCode = authorizationCode;
    }

}