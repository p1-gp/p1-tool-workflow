using DotNet.GitHubAction.Models;

namespace DotNet.GitHubAction.Interfaces;

public interface IAutoUpdater
{
    Task<OptionalSuccess<IndexSuccess>> RunRepositoryAsync(string host, string repository, string branch, string accessToken, CancellationToken cancellationToken);
    Task<OptionalSuccess<LogsSuccess>> ReadLogsAsync(string host, string index, string accessToken, CancellationToken cancellationToken);
    Task<OptionalSuccess<Success>> CancelAsync(string host, string index, string accessToken, CancellationToken cancellationToken);
}
