using System.Text.Json.Serialization;

namespace DotNet.GitHubAction.Models;

public class Success : BaseResponse
{
    [JsonPropertyName("status")] public override string Status => "success";
}
