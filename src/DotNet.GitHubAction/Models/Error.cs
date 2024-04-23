using System.Text.Json.Serialization;

namespace DotNet.GitHubAction.Models;

public class Error : BaseResponse
{
    [JsonPropertyName("status")] public override string Status => "error";
    [JsonPropertyName("error")] public required string Message { get; set; }
    [JsonPropertyName("trace")] public List<string>? Trace { get; set; }

    public Exception CreateException()
        => new Exception(Message, Trace is null ? null : new Exception(string.Join("\n", Trace)));
}
