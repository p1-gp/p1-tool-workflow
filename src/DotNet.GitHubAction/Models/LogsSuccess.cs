using System.Text.Json.Serialization;

namespace DotNet.GitHubAction.Models;

public class LogsSuccess : Success
{
    [JsonPropertyName("logs")] public required List<string> Logs { get; set; }
    [JsonPropertyName("code")] public required int? Code { get; set; }
}
