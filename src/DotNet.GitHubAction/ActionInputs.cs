using CommandLine;

namespace DotNet.GitHubAction;

public class ActionInputs
{
    [Option('h', "host",
        Required = true,
        HelpText = "The host of remote executor API")]
    public string Host { get; set; } = null!;

    [Option('r', "repository",
        Required = true,
        HelpText = "The repository name")]
    public string Repository { get; set; } = null!;

    [Option('b', "branch",
        Required = true,
        HelpText = "The branch name")]
    public string Branch { get; set; } = null!;

    [Option('a', "access_token",
        Required = true,
        HelpText = "AccessToken for remote executor API")]
    public string AccessToken { get; set; } = null!;
}
