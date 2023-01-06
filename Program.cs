using Microsoft.Extensions.DependencyInjection;
using SpotiBot.Spotify;
using SpotiBot.Spotify.Services;
using Microsoft.Extensions.Configuration;
using SpotiBot.Common.DependencyInjection;
namespace SpotiBot;

public static class Program
{
    private static IServiceCollection _services;

    public static void Main(string[] args)
    {
        _services = GetServiceCollection();
        App.Run(_services.BuildServiceProvider());
    }

    private static IServiceCollection GetServiceCollection()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        return services;
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        IConfigurationBuilder configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");
        services.AddScoped<IShowService, ShowService>();
        services.AddScoped<SpotifyApiClient>();
        services.AddHttpClient();
        services.AddSpotifyApiClient();

        services.AddMemoryCache();
    }

    private static string Inject()
    {

        return "";
    }
}







