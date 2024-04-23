using DotNet.GitHubAction.Models;

namespace DotNet.GitHubAction.Extensions;

public static class OptionalExtension
{
    public static Task<T> OrThrow<T>(this Task<OptionalSuccess<T>> optional)
        where T : Success
        => optional.Next(v => v.GetOrThrow());
}
