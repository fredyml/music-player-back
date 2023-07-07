using Microsoft.AspNetCore.Mvc;
using music_player.Core.Interfaces;

namespace music_player.Controllers
{
    public class SpotifyController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;

        public SpotifyController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet("albums/{id}")]
        public async Task<IActionResult> GetAlbum(string id)
        {
            try
            {
                var album = await _spotifyService.GetAlbumAsync(id);
                return Ok(album);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("artists/{id}")]
        public async Task<IActionResult> GetArtist(string id)
        {
            try
            {
                var artist = await _spotifyService.GetArtistAsync(id);
                return Ok(artist);
            }
            catch (Exception ex)
            {
               
                return BadRequest(ex.Message);
            }
        }
    }
}
