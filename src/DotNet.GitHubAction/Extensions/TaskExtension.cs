namespace DotNet.GitHubAction.Extensions;

public static class TaskExtension
{
    public static async Task<TOut> Next<TIn, TOut>(this Task<TIn> task, Func<TIn, TOut> func)
        => func(await task);
    public static async Task<TOut> Next<TIn, TOut>(this Task<TIn> task, Func<TIn, Task<TOut>> func)
        => await func(await task);
}
