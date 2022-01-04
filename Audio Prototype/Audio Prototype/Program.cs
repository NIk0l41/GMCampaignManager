using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace Audio_Prototype
{
    class Program
    {
        public delegate void myMethod();

        public static async Task Main()
        {
            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest("b3afb4fe0e1044cb82f8f1eb3338b623", "84498e679e764a63b5a098ffa30f7070");
            var response = await new OAuthClient(config).RequestToken(request);

            var spotify = new SpotifyClient(config.WithToken(response.AccessToken));
            var qRequest = new PlayerAddToQueueRequest("0BIOzJBQIFQMvCqECIqvNh");

            await spotify.Player.SkipNext();
        }
    }
}
