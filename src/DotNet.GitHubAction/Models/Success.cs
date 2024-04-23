using System.Text.Json.Serialization;

namespace DotNet.GitHubAction.Models;

public abstract class Success : BaseResponse
{
    [JsonPropertyName("status")] public override string Status => "success";
}
