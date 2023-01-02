
namespace SpotiBot.Spotify.Models;

public class SearchCriteria {
    public string Query {get; set;}
    public List<MediaType> Types {get; set;}
    public int Limit {get; set;}
    public int Offset {get; set;}
}

public class SearchRequest {
    public string q {get; set;}
    public string[] type {get; set;}
    public int limit {get; set;}
    public int offset {get; set;}
}

public enum MediaType {
    Album,
    Artist,
    Playlist,
    Track,
    Show,
    Episode,
    Audiobook
}