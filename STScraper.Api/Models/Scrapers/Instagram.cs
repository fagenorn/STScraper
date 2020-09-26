using System;
using System.Net;
using System.Threading.Tasks;

using Newtonsoft.Json;

using STScraper.Api.Exceptions;
using STScraper.Api.Models.Scrapers.JSON;

namespace STScraper.Api.Models.Scrapers
{
    public class Instagram : IUserScraper
    {
        private readonly string _password;

        private readonly string _username;

        private string _csrf;

        private bool _isLoggedIn;

        public Instagram(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public Task Init() { return CheckTryLogin(); }

        public async Task<IUser> GetUserAsync(string username)
        {
            var request = new RequestBuilder().SetUrl($"https://www.instagram.com/{username}/?__a=1")
                                              .AddHeader("X-CSRFToken", _csrf)
                                              .Build();

            using var response = await Web.SendAsync(request);

            if ( response.StatusCode == HttpStatusCode.TooManyRequests )
            {
                throw new ThrottledException();
            }

            return JsonConvert.DeserializeObject<InstagramUser.Root>(await response.Content.ReadAsStringAsync());
        }

        private async Task CheckTryLogin()
        {
            if ( _isLoggedIn )
            {
                return;
            }

            var request = new RequestBuilder().SetUrl("https://www.instagram.com/")
                                              .Build();

            using (var response = await Web.SendAsync(request))
            {
                _csrf = (await response.Content.ReadAsStringAsync()).RegexMatch(@"""csrf_token"":""(\w*)""").Groups[1].Value;
            }

            request = new RequestBuilder().SetUrl("https://www.instagram.com/accounts/login/ajax/")
                                          .AddPost("username", _username)
                                          .AddPost("enc_password", $"#PWD_INSTAGRAM_BROWSER:0:{DateTimeOffset.Now.ToUnixTimeSeconds()}:{_password}")
                                          .AddHeader("X-Instagram-AJAX", "1")
                                          .AddHeader("X-Requested-With", "XMLHttpRequest")
                                          .AddHeader("X-CSRFToken", _csrf)
                                          .Build();

            using (var response = await Web.SendAsync(request))
            {
                if ( !response.IsSuccessStatusCode )
                {
                    throw new LoginFailedException();
                }

                _isLoggedIn = true;
            }
        }
    }
}