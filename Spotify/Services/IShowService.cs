using SpotiBot.Spotify.Models;

namespace SpotiBot.Spotify.Services;

public interface IShowService 
{
    Task<IEnumerable<Show>> GetAllAsync();
}