namespace music_player.Core.Entities
{
    public class SpotifySettings
    {
        public string BearerToken { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string SpotifyApiUrl { get; set; }
        public string SpotifyTokenUrl { get; set; }
    }
}
