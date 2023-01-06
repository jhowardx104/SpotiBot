using SpotiBot.Common.Authentication;
using SpotiBot.Spotify.Models;
namespace SpotiBot.Spotify.Services;

public class SpotifyApiAuthenticationService : IAuthenticationService
{
    private readonly IMemoryCache _memoryCache;
    private readonly HttpClient _httpClient;

    public SpotifyApiAuthenticationService(IMemoryCache memoryCache, HttpClient client)
    {
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        _httpClient = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<string?> RetrieveToken()
    {
        DateTimeOffset expirationDateTime;
        if(!_memoryCache.TryGetValue<string>("Spotify Auth Token", out var token))
        {
            var response = await _httpClient.PostAsync("/token", null);
            var authToken = JsonConvert.DeserializeObject<SpotifyAuthToken>(await response.Content.ReadAsStringAsync());
            token = authToken?.AccessToken;
            if(authToken is not null && authToken.ExpiresIn > 0 && authToken.AccessToken.Length > 0)
            {
                expirationDateTime = DateTimeOffset.Now.AddSeconds(authToken.ExpiresIn);
                _memoryCache.Set("Spotify Auth Token", token, expirationDateTime);
            }
            else if(authToken is not null && authToken.AccessToken.Length > 0)
            {
                expirationDateTime = DateTimeOffset.Now.AddSeconds(30);
                _memoryCache.Set("Spotify Auth Token", token, expirationDateTime);
            }
        }
        return token;
    }
}