using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using _4chan.NET.Lib;

internal class Program
{
    private const String Board = "biz";
    private static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddCommandLine(args).Build();
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(builder =>
        {
            builder.AddConfiguration(configuration.GetSection("Logging"));
            builder.AddConsole();
            builder.AddDebug();
        });
        serviceCollection.AddHttpClient<Client>(client =>
        {
            client.Timeout = System.Threading.Timeout.InfiniteTimeSpan;
        });
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var _4chanClient = serviceProvider.GetService<Client>();
        var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(nameof(Program));

        var BizThreads = await _4chanClient.Threads_jsonAsync(Board);
        logger.LogInformation("{Boardname} Thread:\r\n\t{Threads}", Board, JsonConvert.SerializeObject(BizThreads));

        serviceProvider.Dispose();
    }
}