namespace SolutionBundler.Core.Models;

public sealed class SolutionInfo
{
    public required string RootPath { get; init; }
    public required string SolutionName { get; init; }
    public DateTime GeneratedAt { get; init; } = DateTime.Now;
    public string DotnetHint { get; init; } = "Bitte .NET SDK Version in README prüfen";
}