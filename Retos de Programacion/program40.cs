//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;
//using System.Web;

//class Program
//{
//    // Configuración inicial (las credenciales deberían manejarse de forma segura en un entorno real)
//    private const string CLIENT_ID = "k4z5ir9ltzcfukl9cfr7uyz5ls80jq";
//    private const string CLIENT_SECRET = "7rb9734d1zcqtp56yl6ngbfei8jnh1";
//    private static string ACCESS_TOKEN = "0g2vzp4bohocsxrn4wg6p9odtaasbz";

//    // Lista de participantes
//    private static readonly List<string> participantes = new List<string>
//    {
//        "Illojuan", "TheGrefg", "Masi", "Fernanfloo", "Spreen",
//        "Rivers_gg", "Quackity", "Vegetta777", "Willyrex", "LolitoFDEZ",
//        "xQc", "Ibai", "Auronplay", "Rubiu5", "NexxuzHD",
//        "Cristinini", "Zeling", "Komanche", "Perxitaa", "Mayichi",
//        "Viviendoenlacalle"
//    };

//    private static readonly HttpClient httpClient = new HttpClient();

//    // Clases para deserialización JSON
//    public class TokenResponse
//    {
//        public string access_token { get; set; }
//        public int expires_in { get; set; }
//        public string token_type { get; set; }
//    }

//    public class UserData
//    {
//        public string id { get; set; }
//        public string login { get; set; }
//        public string display_name { get; set; }
//        public string created_at { get; set; }
//        public int followers { get; set; } // Propiedad añadida para solucionar CS1061
//    }

//    public class UsersResponse
//    {
//        public List<UserData> data { get; set; }
//    }

//    public class FollowersData
//    {
//        public string user_id { get; set; }
//        public string user_login { get; set; }
//        public string user_name { get; set; }
//    }

//    public class FollowersResponse
//    {
//        public List<FollowersData> data { get; set; }
//        public Pagination pagination { get; set; }
//        public int total { get; set; }
//    }

//    public class Pagination
//    {
//        public string cursor { get; set; }
//    }

//    public class UserInfo
//    {
//        public string username { get; set; }
//        public string displayName { get; set; }
//        public int followers { get; set; }
//        public DateTime createdAt { get; set; }
//        public bool found { get; set; }
//    }

//    // Función para renovar el token de acceso
//    static async Task RenovarToken()
//    {
//        try
//        {
//            var content = new FormUrlEncodedContent(new[]
//            {
//                new KeyValuePair<string, string>("client_id", CLIENT_ID),
//                new KeyValuePair<string, string>("client_secret", CLIENT_SECRET),
//                new KeyValuePair<string, string>("grant_type", "client_credentials")
//            });

//            var response = await httpClient.PostAsync("https://id.twitch.tv/oauth2/token", content);

//            if (!response.IsSuccessStatusCode)
//            {
//                throw new Exception($"Error al renovar token: {response.StatusCode}");
//            }

//            var responseContent = await response.Content.ReadAsStringAsync();
//            var tokenData = JsonSerializer.Deserialize<TokenResponse>(responseContent);

//            ACCESS_TOKEN = tokenData.access_token;
//            Console.WriteLine("Token renovado correctamente");
//        }
//        catch (Exception error)
//        {
//            Console.WriteLine($"Error al renovar token: {error.Message}");
//            throw;
//        }
//    }

//    // Función para obtener información de usuarios de Twitch
//    static async Task<List<UserInfo>> ObtenerInfoTwitch(List<string> usernames)
//    {
//        try
//        {
//            // 1. Obtener IDs de usuario
//            var queryParams = string.Join("&", usernames.Select(u => $"login={HttpUtility.UrlEncode(u)}"));
//            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.twitch.tv/helix/users?{queryParams}");

//            request.Headers.Add("Client-ID", CLIENT_ID);
//            request.Headers.Add("Authorization", $"Bearer {ACCESS_TOKEN}");

//            var responseUsers = await httpClient.SendAsync(request);

//            // Si el token es inválido, intentamos renovarlo
//            if (responseUsers.StatusCode == System.Net.HttpStatusCode.Unauthorized)
//            {
//                await RenovarToken();
//                return await ObtenerInfoTwitch(usernames); // Reintentar con nuevo token
//            }

//            if (!responseUsers.IsSuccessStatusCode)
//            {
//                throw new Exception($"Error al obtener usuarios: {responseUsers.StatusCode}");
//            }

//            var usersData = JsonSerializer.Deserialize<UsersResponse>(await responseUsers.Content.ReadAsStringAsync());

//            // 2. Obtener seguidores
//            var usersWithFollowers = new List<UserData>();

//            foreach (var user in usersData.data)
//            {
//                int totalFollowers = 0;
//                string cursor = null;

//                do
//                {
//                    var url = $"https://api.twitch.tv/helix/channels/followers?broadcaster_id={user.id}&first=100";
//                    if (!string.IsNullOrEmpty(cursor))
//                    {
//                        url += $"&after={cursor}";
//                    }

//                    var requestFollowers = new HttpRequestMessage(HttpMethod.Get, url);
//                    requestFollowers.Headers.Add("Client-ID", CLIENT_ID);
//                    requestFollowers.Headers.Add("Authorization", $"Bearer {ACCESS_TOKEN}");

//                    var responseFollowers = await httpClient.SendAsync(requestFollowers);

//                    if (!responseFollowers.IsSuccessStatusCode)
//                    {
//                        throw new Exception($"Error al obtener seguidores: {responseFollowers.StatusCode}");
//                    }

//                    var followersData = JsonSerializer.Deserialize<FollowersResponse>(await responseFollowers.Content.ReadAsStringAsync());
//                    totalFollowers = followersData.total; // Usamos el total directamente de la API
//                    cursor = followersData.pagination?.cursor;
//                } while (!string.IsNullOrEmpty(cursor));

//                usersWithFollowers.Add(new UserData
//                {
//                    id = user.id,
//                    login = user.login,
//                    display_name = user.display_name,
//                    created_at = user.created_at,
//                    followers = totalFollowers // Asignamos los seguidores
//                });
//            }

//            return usersWithFollowers.Select(user => new UserInfo
//            {
//                username = user.login,
//                displayName = user.display_name,
//                followers = user.followers,
//                createdAt = DateTime.Parse(user.created_at),
//                found = true
//            }).ToList();
//        }
//        catch (Exception error)
//        {
//            Console.WriteLine($"Error en ObtenerInfoTwitch: {error.Message}");
//            return new List<UserInfo>();
//        }
//    }

//    // Función principal
//    static async Task Main(string[] args)
//    {
//        try
//        {
//            // Dividimos en chunks para no exceder límites de la API
//            const int chunkSize = 10;
//            var chunks = new List<List<string>>();

//            for (int i = 0; i < participantes.Count; i += chunkSize)
//            {
//                chunks.Add(participantes.Skip(i).Take(chunkSize).ToList());
//            }

//            var results = new List<UserInfo>();

//            foreach (var chunk in chunks)
//            {
//                var chunkResults = await ObtenerInfoTwitch(chunk);
//                results.AddRange(chunkResults);
//            }

//            // Marcamos los usuarios no encontrados
//            var usuariosEncontrados = results.Select(r => r.username.ToLower()).ToList();
//            var noEncontrados = participantes.Where(p => !usuariosEncontrados.Contains(p.ToLower())).ToList();

//            noEncontrados.ForEach(username =>
//            {
//                results.Add(new UserInfo
//                {
//                    username = username,
//                    displayName = username,
//                    followers = 0,
//                    createdAt = DateTime.MinValue,
//                    found = false
//                });
//            });

//            // Ordenamos por seguidores (descendente)
//            var rankingSeguidores = results.OrderByDescending(u => u.followers).ToList();

//            // Ordenamos por antigüedad (ascendente)
//            var rankingAntiguedad = results
//                .Where(user => user.found)
//                .OrderBy(user => user.createdAt)
//                .ToList();

//            // Mostramos resultados
//            Console.WriteLine("=== Ranking por Seguidores ===");
//            for (int i = 0; i < rankingSeguidores.Count; i++)
//            {
//                var user = rankingSeguidores[i];
//                if (user.found)
//                {
//                    Console.WriteLine($"{i + 1}. {user.displayName} - {user.followers.ToString("N0")} seguidores (desde {user.createdAt.ToShortDateString()})");
//                }
//                else
//                {
//                    Console.WriteLine($"{i + 1}. {user.username} - NO ENCONTRADO EN TWITCH");
//                }
//            }

//            Console.WriteLine("\n=== Ranking por Antigüedad ===");
//            for (int i = 0; i < rankingAntiguedad.Count; i++)
//            {
//                var user = rankingAntiguedad[i];
//                Console.WriteLine($"{i + 1}. {user.displayName} - desde {user.createdAt.ToShortDateString()} ({user.followers.ToString("N0")} seguidores)");
//            }

//            Console.WriteLine("\n=== Usuarios no encontrados ===");
//            noEncontrados.ForEach(user => Console.WriteLine($"- {user}"));
//        }
//        catch (Exception error)
//        {
//            Console.WriteLine($"Error en Main: {error.Message}");
//        }
//    }
//}