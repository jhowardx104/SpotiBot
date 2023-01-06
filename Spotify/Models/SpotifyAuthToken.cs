namespace SpotiBot.Spotify.Models;

public class SpotifyAuthToken {
    public string AccessToken { get; set; }
    public string TokenType { get; set; }
    public int ExpiresIn {get; set;}
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow; 
    public bool IsExpired => DateTimeOffset.Now < CreatedAt.AddSeconds(ExpiresIn);
}