namespace music_player.Core.Entities
{
    public class Album
    {
        public string AlbumType { get; set; }
        public int TotalTracks { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string ReleaseDatePrecision { get; set; }
        public Restrictions Restrictions { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
        public List<Copyright> Copyrights { get; set; }
        public List<string> Genres { get; set; }
        public string Label { get; set; }
        public int Popularity { get; set; }
        public List<Artist> Artists { get; set; }
        public Tracks Tracks { get; set; }
    }
}
