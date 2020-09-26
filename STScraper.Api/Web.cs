using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace STScraper.Api
{
    public static class Web
    {
        private static readonly HttpClient Http;

        static Web()
        {
            var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.All, UseCookies = true };
            Http = new HttpClient(handler);
            Http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.102 Safari/537.36 Edg/85.0.564.51");
        }

        public static Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) { return Http.SendAsync(request); }
    }
}