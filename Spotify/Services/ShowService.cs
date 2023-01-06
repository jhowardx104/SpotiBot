using SpotiBot.Spotify.Models;

namespace SpotiBot.Spotify.Services;

public class ShowService: IShowService
{
    private readonly HttpClient _client;
    public ShowService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }
    public async Task<IEnumerable<Show>> GetAllAsync()
    {
        var result = await _client.GetAsync("/search?q=Dungeons&type=show");
        var stringResult = await result.Content.ReadAsStringAsync();
        Console.WriteLine(stringResult);
        
        return new List<Show>(){
            new(){
                Name = "Test Show"
            }
        };
    }
}