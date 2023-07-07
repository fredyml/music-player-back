namespace music_player.Core.Entities
{
    public class Track
    {
        public List<Artist> Artists { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public bool IsPlayable { get; set; }
        public Artist LinkedFrom { get; set; }
        public Restrictions Restrictions { get; set; }
        public string Name { get; set; }
        public string PreviewUrl { get; set; }
        public int TrackNumber { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public bool IsLocal { get; set; }
    }
}
