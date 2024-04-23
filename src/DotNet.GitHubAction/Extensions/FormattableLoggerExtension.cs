using Microsoft.Extensions.Logging;

namespace DotNet.GitHubAction.Extensions;

public static class FormattableLoggerExtension
{
#pragma warning disable CA2254 // Template should be a static expression
    public static void Debug(this ILogger logger, EventId eventId, Exception? exception, FormattableString formattable) => logger.LogDebug(eventId, exception, formattable.Format, formattable.GetArguments());
    public static void Debug(this ILogger logger, EventId eventId, FormattableString formattable) => logger.LogDebug(eventId, formattable.Format, formattable.GetArguments());
    public static void Debug(this ILogger logger, Exception? exception, FormattableString formattable) => logger.LogDebug(exception, formattable.Format, formattable.GetArguments());
    public static void Debug(this ILogger logger, FormattableString formattable) => logger.LogDebug(formattable.Format, formattable.GetArguments());
    public static void Trace(this ILogger logger, EventId eventId, Exception? exception, FormattableString formattable) => logger.LogTrace(eventId, exception, formattable.Format, formattable.GetArguments());
    public static void Trace(this ILogger logger, EventId eventId, FormattableString formattable) => logger.LogTrace(eventId, formattable.Format, formattable.GetArguments());
    public static void Trace(this ILogger logger, Exception? exception, FormattableString formattable) => logger.LogTrace(exception, formattable.Format, formattable.GetArguments());
    public static void Trace(this ILogger logger, FormattableString formattable) => logger.LogTrace(formattable.Format, formattable.GetArguments());
    public static void Information(this ILogger logger, EventId eventId, Exception? exception, FormattableString formattable) => logger.LogInformation(eventId, exception, formattable.Format, formattable.GetArguments());
    public static void Information(this ILogger logger, EventId eventId, FormattableString formattable) => logger.LogInformation(eventId, formattable.Format, formattable.GetArguments());
    public static void Information(this ILogger logger, Exception? exception, FormattableString formattable) => logger.LogInformation(exception, formattable.Format, formattable.GetArguments());
    public static void Information(this ILogger logger, FormattableString formattable) => logger.LogInformation(formattable.Format, formattable.GetArguments());
    public static void Warning(this ILogger logger, EventId eventId, Exception? exception, FormattableString formattable) => logger.LogWarning(eventId, exception, formattable.Format, formattable.GetArguments());
    public static void Warning(this ILogger logger, EventId eventId, FormattableString formattable) => logger.LogWarning(eventId, formattable.Format, formattable.GetArguments());
    public static void Warning(this ILogger logger, Exception? exception, FormattableString formattable) => logger.LogWarning(exception, formattable.Format, formattable.GetArguments());
    public static void Warning(this ILogger logger, FormattableString formattable) => logger.LogWarning(formattable.Format, formattable.GetArguments());
    public static void Error(this ILogger logger, EventId eventId, Exception? exception, FormattableString formattable) => logger.LogError(eventId, exception, formattable.Format, formattable.GetArguments());
    public static void Error(this ILogger logger, EventId eventId, FormattableString formattable) => logger.LogError(eventId, formattable.Format, formattable.GetArguments());
    public static void Error(this ILogger logger, Exception? exception, FormattableString formattable) => logger.LogError(exception, formattable.Format, formattable.GetArguments());
    public static void Error(this ILogger logger, FormattableString formattable) => logger.LogError(formattable.Format, formattable.GetArguments());
    public static void Critical(this ILogger logger, EventId eventId, Exception? exception, FormattableString formattable) => logger.LogCritical(eventId, exception, formattable.Format, formattable.GetArguments());
    public static void Critical(this ILogger logger, EventId eventId, FormattableString formattable) => logger.LogCritical(eventId, formattable.Format, formattable.GetArguments());
    public static void Critical(this ILogger logger, Exception? exception, FormattableString formattable) => logger.LogCritical(exception, formattable.Format, formattable.GetArguments());
    public static void Critical(this ILogger logger, FormattableString formattable) => logger.LogCritical(formattable.Format, formattable.GetArguments());
#pragma warning restore CA2254 // Template should be a static expression
}