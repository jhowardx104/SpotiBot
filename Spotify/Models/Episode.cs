namespace SpotiBot.Spotify.Models;

public class Episode
    {
        public string AudioPreviewUrl { get; set; }
        public string Description { get; set; }
        public string HtmlDescription { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public Dictionary<string, string> ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public bool IsExternallyHosted { get; set; }
        public bool IsPlayable { get; set; }
        public string Language { get; set; }
        public List<string> Languages { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDatePrecision { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public Dictionary<string, string> Restrictions { get; set; }
        public Show Show { get; set; }
    }