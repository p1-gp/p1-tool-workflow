using CommandLine;
using DotNet.GitHubAction;
using DotNet.GitHubAction.Interfaces;
using DotNet.GitHubAction.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

Log.Logger = new LoggerConfiguration()
        .WriteTo.Console()
        .CreateLogger();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(v => v.AddSerilog())
    .ConfigureServices(v => v
        .AddSingleton(Log.Logger)
        .AddSingleton<IAutoUpdater, AutoUpdater>()
        .AddSingleton<RemoteExecutor>())
    .Build();

static TService Get<TService>(IHost host)
    where TService : notnull =>
    host.Services.GetRequiredService<TService>();

static async Task StartExecuteAsync(ActionInputs inputs, IHost host)
{
    RemoteExecutor executor = Get<RemoteExecutor>(host);
    using CancellationTokenSource tokenSource = new();
    Console.CancelKeyPress += (s,e) => tokenSource.Cancel();

    int resultCode = await executor.ExecuteAsync(inputs.Host, inputs.Repository, inputs.Branch, inputs.AccessToken, tokenSource.Token);
    Environment.Exit(resultCode);
}

var parser = Parser.Default.ParseArguments<ActionInputs>(() => new(), args);
parser.WithNotParsed(
    errors =>
    {
        Log.Logger.Error(string.Join(Environment.NewLine, errors.Select(error => error.ToString())));
        Environment.Exit(2);
    });

await parser.WithParsedAsync(options => StartExecuteAsync(options, host));
await host.RunAsync();
