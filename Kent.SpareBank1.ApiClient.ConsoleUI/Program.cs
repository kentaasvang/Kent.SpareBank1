// See https://aka.ms/new-console-template for more information

// get data from appsettings.json

using Kent.SpareBank1.ApiClient;
using Kent.SpareBank1.ApiClient.ConsoleUI;
using Microsoft.Extensions.Configuration;

var currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine($"Current directory: {currentDirectory}");

// const string pathToEnvFile = "/home/kent/repos/Kent.SpareBank1.ApiClient/.env";
const string pathToEnvFile = "../../../../.env";
DotNetEnv.Env.Load(pathToEnvFile);

var builder = new ConfigurationBuilder()
    .AddEnvironmentVariables();
    
IConfiguration configuration = builder.Build();

var redirectUri = configuration["REDIRECT_URI"] ?? throw new ArgumentNullException("REDIRECT_URI");
var authorizationUri = configuration["AUTHORIZATION_URI"] ?? throw new ArgumentNullException("AUTHORIZATION_URI");
var clientId = configuration["CLIENT_ID"] ?? throw new ArgumentNullException("CLIENT_ID");
var clientSecret = configuration["CLIENT_SECRET"] ?? throw new ArgumentNullException("CLIENT_SECRET");
var authorizationCode = configuration["AUTHORIZATION_CODE"] ?? throw new ArgumentNullException("AUTHORIZATION_CODE");

var environmentVariables = new EnvironmentVariables(
    new Uri(redirectUri), 
    new Uri(authorizationUri), 
    clientId, 
    clientSecret, 
    authorizationCode
);

var apiClientSettings = new ApiClientSettings()
{
    RedirectUri = environmentVariables.RedirectUri, 
    ApiAuthorizationUri = environmentVariables.AuthorizationUri,
    ClientId = environmentVariables.ClientId, 
    ClientSecret = environmentVariables.ClientSecret,
    AuthorizationCode = environmentVariables.AuthorizationCode,
};

var apiClient = new ApiClient(apiClientSettings);

var result = apiClient.GetAccessToken().Result;

if (result.IsSuccess)
{
    Console.WriteLine($"Access token: {result.Value.AccessToken}");
    Console.WriteLine($"Token type: {result.Value.TokenType}");
    Console.WriteLine($"Expires in: {result.Value.ExpiresIn}");
    Console.WriteLine($"Refresh token: {result.Value.RefreshToken}");
}
else
{
    Console.WriteLine($"Error: {result.ErrorMessage}");
}

