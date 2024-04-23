using DotNet.GitHubAction.Models;

namespace DotNet.GitHubAction.Interfaces;

public interface IAutoUpdater
{
    Task<OptionalSuccess<IndexSuccess>> RunRepositoryAsync(string host, string repository, string accessToken, CancellationToken cancellationToken);
    Task<OptionalSuccess<LogsSuccess>> ReadLogsAsync(string host, string index, string accessToken, CancellationToken cancellationToken);
}
