using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Kent.SpareBank1.ApiClient;

public class ApiClient(ApiClientSettings settings)
{
    public async Task<ApiClientResult<ApiAccessToken>> GetAccessToken()
    { 
        // setup
        var request = new HttpRequestMessage(HttpMethod.Post, settings.ApiAuthorizationUri);
        
        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "authorization_code" },
            { "code", settings.AuthorizationCode },
            { "redirect_uri", settings.RedirectUri.ToString() },
            { "client_id", settings.ClientId },
            { "client_secret", settings.ClientSecret }
        });
        
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
        
        // call
        var httpClient = new HttpClient(); 
        var response = await httpClient.SendAsync(request);
        
        // validation & serialize
        try
        {
            response.EnsureSuccessStatusCode();
            var accessToken = await response.Content.ReadFromJsonAsync<ApiAccessToken>();
            
            if (accessToken is null)
            {
                throw new Exception("Failed to deserialize the access token");
            }
            
            return new ApiClientResult<ApiAccessToken> { IsSuccess = true, Value = accessToken };
        }
        catch (Exception ex)
        {
            return new ApiClientResult<ApiAccessToken> { IsSuccess = false, ErrorMessage = ex.Message };
        } 
    }
}