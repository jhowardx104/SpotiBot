namespace SpotiBot.Spotify.Models;

public class Show
{
    public List<string> AvailableMarkets { get; set; }
    public List<Copyright> Copyrights { get; set; }
    public string Description { get; set; }
    public string HtmlDescription { get; set; }
    public Dictionary<string, string> ExternalUrls { get; set; }
    public string Href { get; set; }
    public string Id { get; set; }
    public bool Explicit {get; set;}
    public List<Image> Images { get; set; }
    public bool IsExternallyHosted { get; set; }
    public List<string> Languages { get; set; }
    public string MediaType { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public string Type { get; set; }
    public string Uri { get; set; }
    public Episodes Episodes { get; set; }
}

public class Episodes
{
    public string Href { get; set; }
    public List<Episode> Items { get; set; }
    public int Limit { get; set; }
    public string Next { get; set; }
    public int Offset { get; set; }
    public string Previous { get; set; }
    public int Total { get; set; }
}

    