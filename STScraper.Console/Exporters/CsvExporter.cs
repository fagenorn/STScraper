using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using CsvHelper;

using STScraper.Api.Models;

namespace STScraper.Console.Exporters
{
    public class CsvExporter : IExporter
    {
        public async Task UserExport(IUser user, params string[] args)
        {
            if ( user == null )
            {
                return;
            }

            var file = new FileInfo(args[0]);
            if ( !file.Exists )
            {
                await using var fs     = file.Open(FileMode.CreateNew);
                await using var writer = new StreamWriter(fs, Encoding.UTF8);
                await using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<IUser>();
                    await csv.FlushAsync();
                    await writer.WriteAsync("\r\n");
                    await writer.FlushAsync();
                }
            }

            {
                await using var fs     = file.Open(FileMode.Append);
                await using var writer = new StreamWriter(fs, Encoding.UTF8);
                await using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    await csv.WriteRecordsAsync(new[] { user });
                }
            }
        }
    }
}