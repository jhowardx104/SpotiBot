using Microsoft.Extensions.DependencyInjection;
using SpotiBot.Spotify;

namespace SpotiBot;

public static class App
{
    public static async void Run(IServiceProvider provider)
    {
        var spotifyApiClient = provider.GetRequiredService<SpotifyApiClient>();
        while (true)
        {
            Thread.Sleep(2000);
            Console.WriteLine((await spotifyApiClient.GetShowsAsync()).First().Name);
        }
    }
}