﻿using DotNet.GitHubAction.Interfaces;
using DotNet.GitHubAction.Models;
using System.Buffers.Text;
using System.Text;
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
        JsonObject json;
        try
        {
            json = JsonNode.Parse(rawJson)!.AsObject();
        }
        catch (Exception e)
        {
            throw new Exception($"JSON READ ERROR OF '{Convert.ToBase64String(Encoding.UTF8.GetBytes($"{host}/{repository}/{branch}"))}': {rawJson}", e);
        }
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
}
