using System.Net;
using System.Threading.Tasks;

using Newtonsoft.Json;

using STScraper.Api.Exceptions;
using STScraper.Api.Models.Scrapers.JSON;

namespace STScraper.Api.Models.Scrapers
{
    public class TikTok : IUserScraper
    {
        public Task Init() { return Task.CompletedTask; }

        public async Task<IUser> GetUserAsync(string username)
        {
            var request = new RequestBuilder().SetUrl($"https://www.tiktok.com/node/share/user/@{username}")
                                              .Build();

            using var response = await Web.SendAsync(request);

            if ( response.StatusCode == HttpStatusCode.TooManyRequests )
            {
                throw new ThrottledException();
            }

            return JsonConvert.DeserializeObject<TikTokUser.Root>(await response.Content.ReadAsStringAsync());
        }
    }
}