using music_player.Core.Entities;

namespace music_player.Core.Interfaces
{
    public interface ISpotifyService
    {
        Task<Album> GetAlbumAsync(string id);
        Task<Artist> GetArtistAsync(string id);
    }
}
