namespace DotNet.GitHubAction.Models;

public class OptionalSuccess<T>
    where T : Success
{
    public required T? Success { get; set; }
    public required Error? Error { get; set; }

    public T GetOrThrow()
        => Success ?? throw Error?.CreateException() ?? new NotSupportedException("`Success` and `Error` is nullable");

    public static implicit operator OptionalSuccess<T>(T success)
        => new OptionalSuccess<T>
        {
            Success = success,
            Error = null
        };
    public static implicit operator OptionalSuccess<T>(Error error)
        => new OptionalSuccess<T>
        {
            Success = null,
            Error = error
        };
}
