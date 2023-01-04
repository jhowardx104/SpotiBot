using Microsoft.Extensions.DependencyInjection;
using SpotiBot.Spotify.Models;
namespace SpotiBot.Common.DependencyInjection;

public static class SpotifyApiDIExtensions 
{
    private static AuthToken _currentLogin;
    public static IServiceCollection AddSpotifyApiClient(this IServiceCollection services)
    {
        if (_currentLogin is not null && !_currentLogin.IsExpired)
        {
            
        }
        return services;
    }
}