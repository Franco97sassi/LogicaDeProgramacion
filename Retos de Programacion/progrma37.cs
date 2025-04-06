using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    const string CLIENT_ID = "0a5418e910fa4cefaa7854c03580a0a1";
    const string CLIENT_SECRET = "7ccc18f3179142cf9b20d0d6f1119280";
    const string TOKEN_URL = "https://accounts.spotify.com/api/token";
    const string API_URL = "https://api.spotify.com/v1";

    static async Task<string> GetAccessTokenAsync()
    {
        using var client = new HttpClient();

        var auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{CLIENT_ID}:{CLIENT_SECRET}"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);

        var requestData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        });

        var response = await client.PostAsync(TOKEN_URL, requestData);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseJson);
        return tokenResponse.AccessToken;
    }

    static async Task<Artist> SearchArtistAsync(string artistName, string accessToken)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await client.GetAsync($"{API_URL}/search?q={Uri.EscapeDataString(artistName)}&type=artist&limit=1");
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var searchResult = JsonSerializer.Deserialize<SearchResponse>(responseJson);
        return searchResult.Artists.Items[0];
    }

    static async Task<List<Album>> GetArtistAlbumsAsync(string artistId, string accessToken)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await client.GetAsync($"{API_URL}/artists/{artistId}/albums?limit=50");
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var albums = JsonSerializer.Deserialize<AlbumsResponse>(responseJson);
        return albums.Items;
    }

    static async Task<List<Track>> GetTopTracksAsync(string artistId, string accessToken)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await client.GetAsync($"{API_URL}/artists/{artistId}/top-tracks?market=ES");
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var tracks = JsonSerializer.Deserialize<TracksResponse>(responseJson);
        return tracks.Tracks;
    }

    static async Task CompareArtistsAsync()
    {
        try
        {
            var accessToken = await GetAccessTokenAsync();
            var oasis = await SearchArtistAsync("Oasis", accessToken);
            var linkinPark = await SearchArtistAsync("Linkin Park", accessToken);

            if (oasis == null || linkinPark == null)
                throw new Exception("No se encontraron ambos artistas");

            var oasisTopTracks = await GetTopTracksAsync(oasis.Id, accessToken);
            var linkinParkTopTracks = await GetTopTracksAsync(linkinPark.Id, accessToken);

            var oasisAlbums = await GetArtistAlbumsAsync(oasis.Id, accessToken);
            var linkinParkAlbums = await GetArtistAlbumsAsync(linkinPark.Id, accessToken);

            Console.WriteLine("=== Comparación de popularidad en Spotify ===");
            Console.WriteLine("\n--- Estadísticas generales ---");
            Console.WriteLine($"Oasis - Seguidores: {oasis.Followers.Total:N0}");
            Console.WriteLine($"Linkin Park - Seguidores: {linkinPark.Followers.Total:N0}");
            Console.WriteLine($"Oasis - Popularidad: {oasis.Popularity}/100");
            Console.WriteLine($"Linkin Park - Popularidad: {linkinPark.Popularity}/100");

            Console.WriteLine("\n--- Canciones más populares ---");
            Console.WriteLine($"Oasis - Canción más popular: \"{oasisTopTracks[0].Name}\" ({oasisTopTracks[0].Popularity}/100)");
            Console.WriteLine($"Linkin Park - Canción más popular: \"{linkinParkTopTracks[0].Name}\" ({linkinParkTopTracks[0].Popularity}/100)");

            Console.WriteLine("\n--- Álbumes ---");
            Console.WriteLine($"Oasis - Total de álbumes: {oasisAlbums.Count}");
            Console.WriteLine($"Linkin Park - Total de álbumes: {linkinParkAlbums.Count}");

            var oasisScore = oasis.Followers.Total + (oasis.Popularity * 10000) + (oasisTopTracks[0].Popularity * 1000);
            var linkinParkScore = linkinPark.Followers.Total + (linkinPark.Popularity * 10000) + (linkinParkTopTracks[0].Popularity * 1000);

            Console.WriteLine("\n--- Resultado final ---");
            if (oasisScore > linkinParkScore)
                Console.WriteLine("¡Oasis es más popular en Spotify!");
            else if (linkinParkScore > oasisScore)
                Console.WriteLine("¡Linkin Park es más popular en Spotify!");
            else
                Console.WriteLine("¡Ambas bandas tienen una popularidad similar en Spotify!");

            Console.WriteLine($"Puntuación Oasis: {oasisScore:N0}");
            Console.WriteLine($"Puntuación Linkin Park: {linkinParkScore:N0}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en la comparación: {ex.Message}");
        }
    }

    static async Task Main(string[] args)
    {
        await CompareArtistsAsync();
    }

    // Clases auxiliares para deserialización

    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }

    public class Followers
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

    public class Artist
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("followers")]
        public Followers Followers { get; set; }

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
    }

    public class SearchArtists
    {
        [JsonPropertyName("items")]
        public List<Artist> Items { get; set; }
    }

    public class SearchResponse
    {
        [JsonPropertyName("artists")]
        public SearchArtists Artists { get; set; }
    }

    public class Album
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class AlbumsResponse
    {
        [JsonPropertyName("items")]
        public List<Album> Items { get; set; }
    }

    public class Track
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
    }

    public class TracksResponse
    {
        [JsonPropertyName("tracks")]
        public List<Track> Tracks { get; set; }
    }
}
