using Microsoft.Extensions.Options;
using music_player.Core.Entities;
using music_player.Core.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace music_player.Infrastructure.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string spotifyApiUrl;
        private readonly string spotifyTokenUrl;
        private readonly string _bearerToken;
        private readonly string clientId;
        private readonly string clientSecret;

        public SpotifyService(IHttpClientFactory httpClientFactory, IOptions<SpotifySettings> spotifySettings)
        {
            _httpClientFactory = httpClientFactory;
            clientId = spotifySettings.Value.ClientId;
            clientSecret = spotifySettings.Value.ClientSecret;
            spotifyApiUrl = spotifySettings.Value.SpotifyApiUrl;
            spotifyTokenUrl = spotifySettings.Value.SpotifyTokenUrl;
            _bearerToken = GetAccessTokenAsync().Result;
        }

        public async Task<Album> GetAlbumAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

            var response = await client.GetAsync($"{spotifyApiUrl}/albums/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var album = JsonConvert.DeserializeObject<Album>(jsonResponse);
                return album;
            }
            else
            {
                throw new Exception("No se pudo obtener la información del álbum de Spotify.");
            }
        }

        public async Task<Artist> GetArtistAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

            var response = await client.GetAsync($"{spotifyApiUrl}/artists/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var artist = JsonConvert.DeserializeObject<Artist>(jsonResponse);
                return artist;
            }
            else
            {
                throw new Exception("No se pudo obtener la información del artista de Spotify.");
            }
        }

        private async Task<string> GetAccessTokenAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Post, spotifyTokenUrl);

            var byteArray = new UTF8Encoding().GetBytes($"{clientId}:{clientSecret}");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        {"grant_type", "client_credentials"}
    });

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
                return data["access_token"];
            }
            else
            {
                throw new Exception("No se pudo obtener el token de acceso de Spotify.");
            }
        }
    }
}



