namespace SpotiBot.Spotify.Models;

public class AuthToken {
    public string AccessToken { get; set; }
    public string TokenType { get; set; }
    public int ExpiresIn {get; set;}
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow; 
    public DateTimeOffset ExpiresAt => CreatedAt.AddSeconds(ExpiresIn);
}