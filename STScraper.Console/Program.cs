using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using CommandLine;

using STScraper.Api.Exceptions;
using STScraper.Api.Models;
using STScraper.Api.Models.Scrapers;
using STScraper.Console.Exporters;

namespace STScraper.Console
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            System.Console.OutputEncoding = Encoding.UTF8;
            var exporter = new CsvExporter();

            var parsedArguments = Parser.Default.ParseArguments<IgOptions, TiktokOptions>(args);
            var progressBar     = new ProgressBar();
            await parsedArguments.WithParsedAsync<IgOptions>(async o =>
                                                             {
                                                                 var users = await File.ReadAllLinesAsync(o.Input);
                                                                 await foreach ( var user in ScrapeUsers(new Instagram(o.Username, o.Password), o, progressBar, users) )
                                                                 {
                                                                     await exporter.UserExport(user, o.Output);
                                                                 }

                                                                 progressBar.Report("Completed.");
                                                                 progressBar.Dispose();
                                                             });

            await parsedArguments.WithParsedAsync<TiktokOptions>(async o =>
                                                                 {
                                                                     var users = await File.ReadAllLinesAsync(o.Input);
                                                                     await foreach ( var user in ScrapeUsers(new TikTok(), o, progressBar, users) )
                                                                     {
                                                                         await exporter.UserExport(user, o.Output);
                                                                     }

                                                                     progressBar.Report("Completed.");
                                                                     progressBar.Dispose();
                                                                 });
        }

        private static async IAsyncEnumerable<IUser> ScrapeUsers(IUserScraper scraper, ICommonOptions options, ProgressBar progress, params string[] users)
        {
            try
            {
                await scraper.Init();
            }
            catch (LoginFailedException)
            {
                progress.Report("Login Failed.");

                yield break;
            }

            var totalProgress   = users.Length;
            var currentProgress = 0.0;
            var usersCopy       = new Queue<string>(users);
            var tasks           = new List<Task<IUser>>();
            while ( usersCopy.Count > 0 || tasks.Count > 0 )
            {
                if ( tasks.Count >= options.Threads || usersCopy.Count == 0 )
                {
                    var done = await Task.WhenAny(tasks);
                    tasks.Remove(done);
                    currentProgress++;
                    progress.Report(currentProgress / totalProgress);

                    if ( done.IsCompletedSuccessfully && !string.IsNullOrWhiteSpace(done.Result.Username) )
                    {
                        progress.Report($"Scraped {done.Result.Username}");

                        yield return done.Result;
                    }
                    else if ( done.Exception?.InnerException is ThrottledException )
                    {
                        progress.Report("Throttled, try again later.");
                    }
                }
                else
                {
                    tasks.Add(scraper.GetUserAsync(usersCopy.Dequeue()));
                    await Task.Delay(options.Delay);
                }
            }
        }

        private interface ICommonOptions
        {
            [Option('o', "output", Required = true, HelpText = "The output file.")]
            public string Output { get; set; }

            [Option('d', "delay", Required = false, HelpText = "The delay (in milliseconds) between scraping users.", Default = 50)]
            public int Delay { get; set; }

            [Option('t', "threads", Required = false, HelpText = "The maximum number of threads to use.", Default = 50)]
            public int Threads { get; set; }
        }

        [Verb("ig", HelpText = "Instagram User Scraper.")]
        public class IgOptions : ICommonOptions
        {
            [Option('i', "input", Required = true, HelpText = "The input file to be processed.")]
            public string Input { get; set; }

            [Option('u', "usernamne", Required = true, HelpText = "Your Instagram username.")]
            public string Username { get; set; }

            [Option('p', "password", Required = true, HelpText = "Your Instagram password.")]
            public string Password { get; set; }

            public string Output { get; set; }

            public int Delay { get; set; }

            public int Threads { get; set; }
        }

        [Verb("tiktok", HelpText = "TikTok User Scraper.")]
        public class TiktokOptions : ICommonOptions
        {
            [Option('i', "input", Required = true, HelpText = "The input file to be processed.")]
            public string Input { get; set; }

            public string Output { get; set; }

            public int Delay { get; set; }

            public int Threads { get; set; }
        }
    }
}