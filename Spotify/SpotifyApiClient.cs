using SpotiBot.Spotify.Models;
using SpotiBot.Spotify.Services;

namespace SpotiBot.Spotify;

public class SpotifyApiClient {
    private readonly IShowService _shows;

    public SpotifyApiClient(IShowService showService)
    {
        _shows = showService ?? throw new ArgumentNullException(nameof(showService));
    }

#region Shows

    public async Task<IEnumerable<Show>> GetShowsAsync() => await _shows.GetAllAsync();

#endregion
}