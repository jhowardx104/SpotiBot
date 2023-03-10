using Microsoft.Extensions.DependencyInjection;
using SpotiBot.Spotify.Models;
using SpotiBot.Spotify;
using SpotiBot.Common.Handlers;
using SpotiBot.Common.Authentication;
using SpotiBot.Spotify.Services;
using Microsoft.Extensions.Configuration;

namespace SpotiBot.Common.DependencyInjection;

public static class SpotifyApiDIExtensions 
{
    public static IServiceCollection AddSpotifyApiClient(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<OAuthDelegatingHandler>();

        var authUrl = config.GetRequiredSection("Spotify:AuthUrl").Value;

        services.AddHttpClient("SpotifyAuthApiClient").ConfigureHttpClient(c => c.BaseAddress = new Uri(authUrl));
        services.AddScoped(provider => {
            var factory = provider.GetRequiredService<IHttpClientFactory>();
            var client = factory.CreateClient("SpotifyAuthApiClient");
            return new SpotifyApiAuthenticationService(provider.GetRequiredService<IMemoryCache>(), client);
        });

        var baseUrl = config.GetRequiredSection("Spotify:BaseUrl").Value;

        services.AddHttpClient("SpotifyApiHttpClient", c => c.BaseAddress = new Uri(baseUrl)).AddHttpMessageHandler(provider => {
            return new OAuthDelegatingHandler(provider.GetRequiredService<SpotifyApiAuthenticationService>());
        });

        services.AddScoped<IShowService>(provider => {
            var factory = provider.GetRequiredService<IHttpClientFactory>();
            var client = factory.CreateClient("SpotifyApiHttpClient");
            return new ShowService(client);
        });

        services.AddScoped<SpotifyApiClient>();
        
        return services;
    }
}