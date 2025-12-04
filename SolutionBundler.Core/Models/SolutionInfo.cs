namespace SolutionBundler.Core.Models;

/// <summary>
/// Enth‰lt Metadaten zur gescannten Solution, die in das Bundle einflieﬂen.
/// </summary>
public sealed class SolutionInfo
{
    /// <summary>
    /// Absoluter Pfad zum Root-Verzeichnis der Solution.
    /// </summary>
    public required string RootPath { get; init; }

    /// <summary>
    /// Name der Solution-Datei (z. B. "MySolution.sln").
    /// </summary>
    public required string SolutionName { get; init; }

    /// <summary>
    /// Zeitpunkt der Bundlegenerierung.
    /// </summary>
    public DateTime GeneratedAt { get; init; } = DateTime.Now;

    /// <summary>
    /// Hinweis zur .NET-Version, der im Bundle ausgegeben wird.
    /// </summary>
    public string DotnetHint { get; init; } = "Bitte .NET SDK Version in README pr\u00FCfen";
}