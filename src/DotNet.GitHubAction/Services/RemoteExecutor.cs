using DotNet.GitHubAction.Extensions;
using DotNet.GitHubAction.Interfaces;
using DotNet.GitHubAction.Models;
using Serilog;

namespace DotNet.GitHubAction.Services;

public class RemoteExecutor(
    IAutoUpdater autoUpdater,
    ILogger logger)
{
    public async Task<int> ExecuteAsync(string host, string repository, string branch, string accessToken, CancellationToken cancellationToken)
    {
        logger.Information($"Execute {host} in repository {repository}.{branch} logs");
        IndexSuccess indexData = await autoUpdater.RunRepositoryAsync(host, repository, branch, accessToken, cancellationToken).OrThrow();
        string index = indexData.Index;
        try
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(1000, cancellationToken);
                LogsSuccess logs = await autoUpdater.ReadLogsAsync(host, index, accessToken, cancellationToken).OrThrow();
                foreach (string log in logs.Logs)
                    logger.Information($"  {log}");

                if (logs.Code is int code)
                    return code;
            }
        }
        catch (TaskCanceledException)
        {
            logger.Information($"Cancelling execute...");
            await autoUpdater.CancelAsync(host, index, accessToken, CancellationToken.None);
            logger.Information($"Cancelled!");
            throw;
        }
    }
}
