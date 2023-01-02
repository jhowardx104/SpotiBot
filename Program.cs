using Microsoft.Extensions.DependencyInjection;
using SpotiBot.Spotify;
using SpotiBot.Spotify.Services;

namespace SpotiBot;

public static class Program
{

    private static IServiceCollection services;

    public static void Main(string[] args)
    {
        services = GetServiceCollection();
        App.Run(services.BuildServiceProvider());
    }

    private static IServiceCollection GetServiceCollection()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        return services;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IShowService, ShowService>();
        services.AddScoped<SpotifyApiClient>();
    }
}







