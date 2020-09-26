using System.Threading.Tasks;

using STScraper.Api.Models;

namespace STScraper.Console.Exporters
{
    public class ConsoleExporter : IExporter
    {
        public Task UserExport(IUser user, params string[] args)
        {
            System.Console.WriteLine($"[*] Username[{user.Username}] Nickname[{user.Nickname}] Bio[{user.Bio}] Website[{user.Website}] Email[{user.Email}] Followers[{user.Followers}] Following[{user.Following}] ProfileImage[{user.ProfileImage}]");

            return Task.CompletedTask;
        }
    }
}