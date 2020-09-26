using System.Threading.Tasks;

using STScraper.Api.Models;

namespace STScraper.Console
{
    public interface IExporter
    {
        Task UserExport(IUser user, params string[] args);
    }
}