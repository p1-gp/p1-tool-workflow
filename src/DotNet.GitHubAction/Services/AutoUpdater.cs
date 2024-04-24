using DotNet.GitHubAction.Interfaces;
using DotNet.GitHubAction.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace DotNet.GitHubAction.Services;

public class AutoUpdater : IAutoUpdater
{
    public async Task<OptionalSuccess<IndexSuccess>> RunRepositoryAsync(string host, string repository, string branch, string accessToken, CancellationToken cancellationToken)
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", accessToken);
        HttpResponseMessage response = await client.PostAsync($"{host}/{repository}/{branch}", null, cancellationToken);
        string rawJson = await response.Content.ReadAsStringAsync(cancellationToken);
        JsonObject json = JsonNode.Parse(rawJson)!.AsObject();
        return json["status"]!.GetValue<string>() switch
        {
            "success" => json.Deserialize<IndexSuccess>()!,
            "error" => json.Deserialize<Error>()!,
            string status => throw new NotSupportedException($"Status '{status}' not supported"),
        };
    }
    public async Task<OptionalSuccess<LogsSuccess>> ReadLogsAsync(string host, string index, string accessToken, CancellationToken cancellationToken)
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", accessToken);
        HttpResponseMessage response = await client.GetAsync($"{host}/logs/{index}", cancellationToken);
        string rawJson = await response.Content.ReadAsStringAsync(cancellationToken);
        JsonObject json = JsonNode.Parse(rawJson)!.AsObject();
        return json["status"]!.GetValue<string>() switch
        {
            "success" => json.Deserialize<LogsSuccess>()!,
            "error" => json.Deserialize<Error>()!,
            string status => throw new NotSupportedException($"Status '{status}' not supported"),
        };
    }
    public async Task<OptionalSuccess<Success>> CancelAsync(string host, string index, string accessToken, CancellationToken cancellationToken)
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", accessToken);
        HttpResponseMessage response = await client.GetAsync($"{host}/cancel/{index}", cancellationToken);
        string rawJson = await response.Content.ReadAsStringAsync(cancellationToken);
        JsonObject json = JsonNode.Parse(rawJson)!.AsObject();
        return json["status"]!.GetValue<string>() switch
        {
            "success" => json.Deserialize<Success>()!,
            "error" => json.Deserialize<Error>()!,
            string status => throw new NotSupportedException($"Status '{status}' not supported"),
        };
    }
}
