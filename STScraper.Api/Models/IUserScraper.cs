using System.Threading.Tasks;

namespace STScraper.Api.Models
{
    public interface IUserScraper
    {
        public Task Init();

        Task<IUser> GetUserAsync(string username);
    }
}