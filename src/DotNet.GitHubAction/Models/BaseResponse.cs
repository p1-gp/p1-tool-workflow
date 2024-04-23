using System.Text.Json;
using System.Text.Json.Serialization;

namespace DotNet.GitHubAction.Models;

public abstract class BaseResponse
{
    [JsonPropertyName("status")] public abstract string Status { get; }

    public sealed override string ToString()
        => JsonSerializer.Serialize(this);
}
