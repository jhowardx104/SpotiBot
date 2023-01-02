using SpotiBot.Spotify.Models;

namespace SpotiBot.Spotify.Services;

public class ShowService: IShowService
{
    public async Task<IEnumerable<Show>> GetAllAsync()
    {
        return new List<Show>(){
            new(){
                Name = "Test Show"
            }
        };
    }
}