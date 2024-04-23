using System.Text.Json.Serialization;

namespace DotNet.GitHubAction.Models;

public class IndexSuccess : Success
{
    [JsonPropertyName("index")] public required string Index { get; set; }
}
